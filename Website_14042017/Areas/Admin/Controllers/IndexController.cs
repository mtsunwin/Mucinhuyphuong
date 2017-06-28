using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class IndexController : AdminBaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return Redirect("/admin/news/allnews");
        }
    }
}