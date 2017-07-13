using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.Common;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class HotLineController : Controller
    {
        // GET: Admin/HotLine
        RWFileText rwFile;

        public HotLineController()
        {
            rwFile = new RWFileText();
        }

        public ActionResult Index()
        {
            ViewBag.HotLine = rwFile.Read("/HotLine.txt");
            return View();
        }
        [HttpPost]
        public ActionResult Index(string hotline)
        {
            if (String.IsNullOrEmpty(hotline))
            {

            }
            else
            {
                rwFile.Write("/HotLine.txt", hotline.Trim());
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetHotLine()
        {
            string hotline = rwFile.Read("/HotLine.txt");
            return Json(hotline, JsonRequestBehavior.AllowGet);
        }
    }
}