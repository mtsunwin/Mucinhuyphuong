using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL prDAL;
        public ProductController()
        {
            prDAL = new ProductDAL();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductList(string type)
        {
            var sp = prDAL.GetByType(type);
            return View(sp);
            //return Json(sp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult protList(string type)
        {
            var sp = prDAL.GetByType(type);
            return Json(sp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductDetails(string name)
        {
            var pro = prDAL.GetByName(name);
            return View(pro);
        }
        public ActionResult GetTop()
        {
            var pros = prDAL.GetTop(6);
            return Json(pros, JsonRequestBehavior.AllowGet);
        }
    }
}