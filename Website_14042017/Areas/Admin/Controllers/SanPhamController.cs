using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class SanPhamController : AdminBaseController
    {
        ProductDAL prDAL;
        ProductTypeDAL prTypeDAL;

        public SanPhamController()
        {
            prDAL = new ProductDAL();
            prTypeDAL = new ProductTypeDAL();

        }
        public ActionResult DanhSachSanPham()
        {
            var prTypes = prTypeDAL.GetAll();
            ViewBag.PrTypes = prTypes;
            var prs = prDAL.GetAll();
            return View(prs);
        }
        [HttpGet]
        public ActionResult Them()
        {
            var prTypes = prTypeDAL.GetAll();
            ViewBag.PrTypes = prTypes;
            return View();
        }
        [HttpPost]
        public ActionResult Them(Product pr, HttpPostedFileBase uploadImg)
        {
            if (uploadImg != null)
            {

                string ext = uploadImg.FileName.Substring(uploadImg.FileName.IndexOf('.'));
                if (ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") || ext.ToLower().Contains("jpeg") || ext.ToLower().Contains("png"))
                {
                    string pic = uploadImg.FileName.Substring(uploadImg.FileName.LastIndexOf('\\') + 1);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/areas/admin/images/Item/"), pic);
                    // file is uploaded
                    uploadImg.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    using (MemoryStream ms = new MemoryStream())
                    {
                        uploadImg.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                    pr.Image = "/areas/admin/images/Item/" + uploadImg.FileName.Substring(uploadImg.FileName.LastIndexOf('\\') + 1);
                    prDAL.Add(pr);
                    return RedirectToAction("DanhSachSanPham");
                }
                return View();
            }
            else
            {
                if (pr != null)
                {
                    prDAL.Add(pr);
                    return RedirectToAction("DanhSachSanPham");
                }
                return View();
            }
        }
        public ActionResult Xoa(string name)
        {
            if (name != null)
            {
                prDAL.Delete(name);
            }
            return RedirectToAction("DanhSachSanPham");
        }
        [HttpGet]
        public ActionResult Sua(string name)
        {
            var pr = prDAL.GetByName(name);
            var prTypes = prTypeDAL.GetAll();
            ViewBag.PrTypes = prTypes;
            return View(pr);
        }
        [HttpPost]
        public ActionResult Sua(Product pr, HttpPostedFileBase uploadImg)
        {
            if (uploadImg != null)
            {

                string ext = uploadImg.FileName.Substring(uploadImg.FileName.IndexOf('.'));
                if (ext.ToLower().Contains("gif") || ext.ToLower().Contains("jpg") || ext.ToLower().Contains("jpeg") || ext.ToLower().Contains("png"))
                {
                    string pic = System.IO.Path.GetFileName(uploadImg.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/areas/admin/images/Item/"), pic);
                    // file is uploaded
                    uploadImg.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    using (MemoryStream ms = new MemoryStream())
                    {
                        uploadImg.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                    pr.Image = "/areas/admin/images/Item/" + uploadImg.FileName;
                    prDAL.Update(pr);
                    return RedirectToAction("DanhSachSanPham");
                }
            }
            if (pr != null)
            {
                prDAL.Update(pr);
                return RedirectToAction("DanhSachSanPham");
            }
            return View(pr.Name);
        }
        public ActionResult ImagesRepository(string nameimg)
        {
            ImageDAL imgDAL;
            DirectoryInfo[] dirInfo;
            List<string> folders;
            imgDAL = new ImageDAL();
            dirInfo = imgDAL.GetDirectoryInfo();
            folders = new List<string>();
            if (dirInfo != null)
                foreach (var item in dirInfo)
                {
                    folders.Add(item.Name);
                }
            if (string.IsNullOrEmpty(nameimg))
            {
                nameimg = folders.FirstOrDefault();
            }
            ViewBag.Folders = folders;
            ViewBag.NameFolder = nameimg;
            FileInfo[] files = imgDAL.GetFileInfor(nameimg);
            return View(files);
        }
    }
}