using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.ModelViews;

namespace Website_14042017.Controllers
{
    public class HomeController : Controller
    {
        NewsDAL newsDAL;
        public HomeController()
        {
            newsDAL = new NewsDAL();
        }
        public ActionResult Index()
        {
            var news = newsDAL.GetIntroduction();
            NewsView _news = new NewsView();
            try
            {
                _news.Id = news.Id;
                _news.Title = news.Title;
                _news.Descrip = news.Descrip;
                _news.Content = news.Content;
                _news.DatePost = news.DatePost.ToLongDateString();
                _news.Author = news.Author;
                _news.Status = news.Status;
            }
            catch
            {
                _news = null;
            }
            return View(_news);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetNew()
        {
            var newses = newsDAL.GetNewNews(5);
            return Json(newses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GioiThieu()
        {
            var news = newsDAL.GetIntroduction();
            NewsView _news = new NewsView();
            try
            {
                _news.Id = news.Id;
                _news.Title = news.Title;
                _news.Descrip = news.Descrip;
                _news.Content = news.Content;
                _news.DatePost = news.DatePost.ToLongDateString();
                _news.Author = news.Author;
                _news.Status = news.Status;
            }
            catch
            {
                _news = null;
            }
            return View(_news);
        }
        public ActionResult DichVu()
        {
            return View();
        }
        public ActionResult Sitemap()
        {
            MenuDAL menuDAL = new MenuDAL();

            var menu0 = menuDAL.GetAllMenu0();
            var menu1 = menuDAL.GetAllMenu1();
            string menu = "";
            int count1 = 0;
            try
            {
                if (menu0 != null)
                    foreach (var item0 in menu0)
                    {
                        count1 = 0;
                        if (menu1 != null)
                            foreach (var item1 in menu1)
                            {
                                if (item1.IdMenuLevel0 == item0.Name)
                                {
                                    count1++;
                                }
                            }

                        if (count1 > 0)
                        {
                            menu += "<tr>";
                            menu += " <td valign='top' style='padding-top:5px;'>";
                            menu += "<div><b><a title = '" + item0.DisplayName + "' href = '" + item0.Link + "'> " + item0.DisplayName + "</a></b></div>";
                            if (menu1 != null)
                                foreach (var item1 in menu1)
                                {
                                    if (item1.IdMenuLevel0 == item0.Name)
                                    {

                                        menu += "<div class='T-sitemap' style='padding-left: 15px;'><a title='" + item1.DisplayName + "' href='" + item1.Link + "'>" + item1.DisplayName + "</a></div>";
                                    }
                                }
                            menu += "</td></tr>";

                        }
                        else
                        {
                            menu += "<tr><td valign = 'top' style = 'padding-top:5px;'><div><b><a title = '" + item0.DisplayName + "' href = '" + item0.Link + "'> " + item0.DisplayName + "</a></b></div></td></tr>";
                        }
                    }
                ViewBag.ContentSitemap = MvcHtmlString.Create(menu);
                return View();
            }
            catch
            {
                ViewBag.ContentSitemap = MvcHtmlString.Create(menu);
                return View();
            }
        }
        public ActionResult LienHe()
        {
            var news = newsDAL.GetContactInfo();
            NewsView _news = new NewsView();
            try
            {
                _news.Id = news.Id;
                _news.Title = news.Title;
                _news.Descrip = news.Descrip;
                _news.Content = news.Content;
                _news.DatePost = news.DatePost.ToLongDateString();
                _news.Author = news.Author;
                _news.Status = news.Status;
            }
            catch
            {
                _news = null;
            }
            return View(_news);
        }
    }
}