using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;

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
    }
}