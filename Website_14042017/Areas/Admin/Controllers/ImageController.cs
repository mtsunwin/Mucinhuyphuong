using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class ImageController : AdminBaseController
    {
        ImageDAL imgDAL;
        DirectoryInfo[] dirInfo;
        List<string> folders;
        public ImageController()
        {
            imgDAL = new ImageDAL();
            dirInfo = imgDAL.GetDirectoryInfo();
            folders = new List<string>();
            if (dirInfo != null)
                foreach (var item in dirInfo)
                {
                    folders.Add(item.Name);
                }
        }
        [HttpGet]
        public ActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = folders.FirstOrDefault();
            }
            ViewBag.Folders = folders;
            ViewBag.NameFolder = name;
            FileInfo[] files = imgDAL.GetFileInfor(name);
            return View(files);
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, string name)
        {
            if (file != null)
            {
                string ext = file.FileName.Substring(file.FileName.IndexOf('.'));
                if (ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") || ext.ToLower().Contains("jpeg") || ext.ToLower().Contains("png"))
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/areas/admin/images/" + name + "/"), pic);
                    // file is uploaded
                    file.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }
            }
            // after successfully uploading redirect the user
            return Redirect("/admin/Image/Index?name=" + name);
        }

        /******** image banner and slider  ***********/

        public ActionResult BannerList()
        {
            try
            {
                var banners = imgDAL.GetAllBanner();
                return View(banners);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBanner(HttpPostedFileBase[] files, string typeImage)
        {
            if (files == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string ext = String.Empty;
            string errorTemp = String.Empty;
            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    foreach (var file in files)
                    {
                        ext = file.FileName.Substring(file.FileName.IndexOf('.'));
                        if (ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") || ext.ToLower().Contains("jpeg") || ext.ToLower().Contains("png"))
                        {
                            string pic = System.IO.Path.GetFileName(file.FileName);
                            string path = System.IO.Path.Combine(
                                                   Server.MapPath("~/areas/admin/Banners/"), pic);
                            // file is uploaded
                            file.SaveAs(path);

                            // save the image path path to the database or you can send image 
                            // directly to database
                            // in-case if you want to store byte[] ie. for DB
                            using (MemoryStream ms = new MemoryStream())
                            {
                                file.InputStream.CopyTo(ms);
                                byte[] array = ms.GetBuffer();
                            }

                            //Save in database
                            imgDAL.Create(new Website_14042017.Models.Image { Name = pic, Href = "", Link = "/Areas/Admin/Banners/" + pic, Type = typeImage });
                        }
                        else
                        {
                            errorTemp += "Thất bại: " + System.IO.Path.GetFileName(file.FileName) + " không hỗ trợ tệp này. \n";
                        }
                    }
                    trans.Complete();

                    if (!string.IsNullOrEmpty(errorTemp))
                    {
                        ViewBag.Error = "Những tệp lưu không thành công: \n" + errorTemp;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("BannerList");
                    }
                }
            }
            catch
            {
                ViewBag.Error = "Hệ thông không sẵn sàng.";
            }
            return View();
        }

        public ActionResult DeleteBanner(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    Website_14042017.Models.Image image = imgDAL.GetBy(name);

                    string path = System.IO.Path.Combine(
                                                   Server.MapPath("~/areas/admin/Banners/"), image.Name);
                    System.IO.File.Delete(path);

                    imgDAL.Delete(image);

                    trans.Complete();
                    return RedirectToAction("BannerList");
                }
            }
            catch
            {
                return Content("Xóa thất bại.");
            }
        }

        public ActionResult SetIsBannerOrSlider(string name, string type)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    Image image = imgDAL.GetBy(name);

                    if (image == null)
                    {
                        return HttpNotFound();
                    }
                    if (image.Type != type)
                    {
                        image.Type = type;
                        imgDAL.Update(image);
                    }

                    trans.Complete();
                    return RedirectToAction("BannerList");
                }
            }
            catch
            {
                return Content("Thay đổi thất bại.");
            }
        }
    }
}