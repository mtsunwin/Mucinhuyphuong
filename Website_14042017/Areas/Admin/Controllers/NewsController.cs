using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Website_14042017.Areas.Admin.Models;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController
    {
        NewsDAL newsDAL;
        ImageDAL imageDAL;
        public NewsController()
        {
            newsDAL = new NewsDAL();
            imageDAL = new ImageDAL();
        }
        string errorMessage = string.Empty;
        const string uploadFolder = "/areas/admin/Images";
        public ActionResult WritePost(ModelNews mews)
        {
            return View(mews);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult WritedPost(ModelNews news, string type)
        {
            bool result = false;
            string _type = type.ToLower();

            if (_type == "lưu")
            {
                result = Save(news);
                if (result)
                {
                    ViewBag.NewsSuccessMessage = "Đã lưu lại bài viết.";
                }
            }
            else if (_type == "đăng")
            {
                if (Validation(news))
                    result = Post(news);
                if (result)
                {
                    ViewBag.NewsSuccessMessage = "Đăng bài viết thành công.";
                }
            }
            else if (_type == "đăng giới thiệu")
            {
                if (Validation(news))
                {
                    result = Post(news, true);
                }

                if (result)
                {
                    ViewBag.NewsSuccessMessage = "Đăng bài giới thiệu thành công.";
                }
            }
            else if (_type == "đăng liên hệ")
            {
                if (Validation(news))
                {
                    result = Post(news, false);
                }

                if (result)
                {
                    ViewBag.NewsSuccessMessage = "Đăng thông tin liên hệ thành công.";
                }
            }
            else if (_type == "viết bài")
            {
                ModelNews modelnews = new ModelNews();
                return View("WritePost", modelnews);
            }
            else if (_type == "xem demo")
            {
                return View("ViewDemo", news);
            }
            else if (_type == "xóa")
            {
                if (string.IsNullOrEmpty(news.Id.ToString()))
                {
                    errorMessage = "Không tìm thấy bài viết" + "\n";
                }
                else
                {
                    result = Post(news);
                }
                if (result)
                {
                    ViewBag.NewsSuccessMessage = "Xóa thành công.";
                    return Redirect("/admin/writePost/Index");
                }
            }
            else if (_type == "tất cả bài viết")
            {
                return Redirect("/admin/news/allnews");
            }
            ViewBag.ErrorNewMessage = errorMessage;
            return View("WritePost", news);
        }
        public ActionResult ImageRepository(string name, string CKEditorFuncNum, string CKEditor, string langCode)
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
            if (string.IsNullOrEmpty(name))
            {
                name = folders.FirstOrDefault();
            }
            ViewBag.Folders = folders;
            ViewBag.NameFolder = name;
            ViewBag.CKEditorFuncNum = CKEditorFuncNum;
            FileInfo[] files = imgDAL.GetFileInfor(name);
            return View(files);
        }
        public ActionResult AllNews(string type)
        {
            if (type == "writing")
            {
                var newsesW = newsDAL.GetWriting();
                return View(newsesW);
            }
            else if (type == "posted")
            {
                var newsesP = newsDAL.GetPosted();
                return View(newsesP);
            }
            var newses = newsDAL.GetAll();
            return View(newses);
        }
        public ActionResult DeleteNews(int id = -1)
        {
            if (id < 0)
            {
                return View("Error");
            }
            var news = newsDAL.GetById(id);
            if (news != null)
            {
                Delete(id);
                return Redirect("/admin/news/allnews");
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult Edit(int id)
        {
            var news = newsDAL.GetById(id);
            if (news != null)
            {
                ModelNews modelnews = new ModelNews();
                modelnews.Id = news.Id;
                modelnews.Title = news.Title;
                modelnews.Descrip = news.Descrip;
                modelnews.Content = news.Content;
                modelnews.Author = news.Author;
                return View("WritePost", modelnews);
            }
            return View("AllNews");
        }
        public ActionResult ViewDemo(ModelNews news)
        {
            return View(news);
        }
        public ActionResult PostNews(int id)
        {
            newsDAL.PostNews(id);
            return Redirect("/admin/news/allnews");
        }
        public ActionResult ViewFull(int id)
        {
            var news = newsDAL.GetById(id);
            return View(news);
        }
        private bool Save(ModelNews news)
        {
            try
            {
                if (news.Id == null)
                {
                    News n = new News();
                    n = TranslateModelNewsToNews(news);
                    n.Status = "writing";
                    n.DatePost = DateTime.Now;
                    newsDAL.Add(n);
                    news.Id = n.Id;
                    return true;
                }
                else
                {
                    News n = new News();
                    string id = news.Id.ToString();
                    n.Id = int.Parse(id);
                    n.Title = news.Title;
                    n.Descrip = news.Descrip;
                    n.Content = news.Content;
                    n.Author = news.Author;
                    n.DatePost = DateTime.Now;
                    newsDAL.UpDate(n);
                    news.Id = n.Id;
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return false;
        }
        private bool Post(ModelNews news)
        {
            News n = TranslateModelNewsToNews(news);
            if (!string.IsNullOrEmpty(n.Descrip) && !string.IsNullOrEmpty(n.Content))
            {
                try
                {
                    if (n != null)
                    {
                        newsDAL.PostNews(n);
                        news.Id = news.Id;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
            else
            {
                errorMessage += "Tất các thông tin phải được hoàn thành.";
            }
            return false;
        }
        private bool Post(ModelNews news, bool introduction)
        {
            News n = TranslateModelNewsToNews(news);
            if (!string.IsNullOrEmpty(n.Descrip) && !string.IsNullOrEmpty(n.Content))
            {
                try
                {
                    if (n != null)
                    {
                        if (introduction)
                        {
                            newsDAL.PostIntroduction(n);
                        }
                        else
                        {
                            newsDAL.PostContactInfo(n);
                        }
                        news.Id = news.Id;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
            else
            {
                errorMessage += "Tất các thông tin phải được hoàn thành.";
            }
            return false;
        }
        private bool Delete(int id)
        {
            try
            {
                newsDAL.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return false;
        }
        private News TranslateModelNewsToNews(ModelNews mnews)
        {
            if (mnews != null)
            {
                News news = new News();
                news.Title = mnews.Title;
                news.Descrip = mnews.Descrip;
                news.Content = mnews.Content;
                news.Author = mnews.Author;
                news.Id = mnews.Id ?? default(int);
                return news;
            }
            return null;
        }
        private bool Validation(ModelNews news)
        {
            if (string.IsNullOrEmpty(news.Id.ToString()))
            {
                errorMessage = "Không tìm thấy bài viết" + "\n";
                return false;
            }

            if (string.IsNullOrEmpty(news.Title))
            {
                errorMessage += "Tiêu đề là bắt buột." + "\n"; ;
                return false;
            }

            if (string.IsNullOrEmpty(news.Descrip))
            {
                errorMessage += "Tóm tắt là bắt buột." + "\n"; ;
                return false;
            }

            if (string.IsNullOrEmpty(news.Content))
            {
                errorMessage += "Nội dung là bắt buột." + "\n"; ;
                return false;
            }

            if (string.IsNullOrEmpty(news.Author))
            {
                errorMessage += "Tác giả bài viết là bắt buột." + "\n"; ;
                return false;
            }
            return true;
        }
        //public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        //{
        //    if (upload.ContentLength <= 0)
        //        return null;
        //    var fileName = Path.GetFileName(upload.FileName);
        //    try
        //    {
        //        int indexStart = fileName.LastIndexOf('.');
        //        string typeImage = fileName.Substring(indexStart+1);
        //        if (typeImage != "bmp" && typeImage != "jpeg" && typeImage != "gif" && typeImage != "png")
        //            return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    var path = Path.Combine(Server.MapPath(uploadFolder), fileName);
        //    upload.SaveAs(path);

        //    var url = string.Format("{0}{1}/{2}/{3}", Request.Url.GetLeftPart(UriPartial.Authority),
        //        Request.ApplicationPath == "/" ? string.Empty : Request.ApplicationPath,
        //        uploadFolder, fileName);
        //    const string message = "Hình ảnh đã lưu thành công.";
        //    var output = string.Format(
        //        "<html><body><script>window.parent.CKEDITOR.tools.callFunction({0}, \"{1}\", \"{2}\");</script></body></html>",
        //        CKEditorFuncNum, url, message);
        //    //Add image model
        //    Image image = new Image();
        //    image.Name = fileName;
        //    image.Link = url;
        //    image.Type = "news";
        //    try
        //    {
        //       // imageDAL.Add(image);
        //    }
        //    catch
        //    {
        //        //
        //    }

        //    return Content(output);
        //}
    }
}