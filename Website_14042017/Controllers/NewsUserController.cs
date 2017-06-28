using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.ModelViews;

namespace Website_14042017.Controllers
{
    public class NewsUserController : Controller
    {
        NewsDAL newsDAL;
        public NewsUserController()
        {
            newsDAL = new NewsDAL();
        }
        public ActionResult Index()
        {
            var newses = newsDAL.GetPosted();
            List<NewsView> _newses = new List<NewsView>();
            if(newses != null)
            {
                foreach(var item in newses)
                {
                    NewsView _news = new NewsView();
                    _news.Id = item.Id;
                    _news.Title = item.Title;
                    _news.Descrip = item.Descrip;
                    _news.Content = item.Content;
                    _news.DatePost = item.DatePost.ToLongDateString();
                    _news.Author = item.Author;
                    _news.Status = item.Status;
                    _newses.Add(_news);
                }
            }
            return View(_newses);
        }
        public ActionResult NewsContent(int id)
        {
            var news = newsDAL.GetById(id);
            return View(news);
        }
    }
}