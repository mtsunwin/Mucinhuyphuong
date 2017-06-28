using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class WebInfosController : Controller
    {
        WebsiteInforDAL infoDAL;

        public WebInfosController()
        {
            infoDAL = new WebsiteInforDAL();
        }
        // GET: Admin/WebInfos
        public ActionResult Index()
        {
            var infos = infoDAL.GetAll().ToList();
            return View(infos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WebsiteInfor info)
        {
            if (ModelState.IsValid)
            {
                var infors = infoDAL.GetAll().ToList();
                if (infors.Count() > 2)
                {
                    ViewBag.Result = "Thông tin tối đa cho footer là 2.";
                    return View(info);
                }
                infoDAL.Add(info);
                ViewBag.Result = "Thêm thông tin thành công.";
            }
            return View(info);
        }

        public ActionResult Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }
            infoDAL.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var info = infoDAL.GetById(id);
            if (info == null)
            {
                return HttpNotFound();
            }

            return View(info);
        }

        [HttpPost]
        public ActionResult Edit(WebsiteInfor info)
        {
            if (info == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                infoDAL.Update(info);
                ViewBag.Result = "Cập nhật thành công.";
            }
            return View(info);
        }

        [HttpGet]
        public ActionResult GetInfo()
        {
            var infos = infoDAL.GetAll().ToList();
            return Json(infos, JsonRequestBehavior.AllowGet);
        }
    }
}