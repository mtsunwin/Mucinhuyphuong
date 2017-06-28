using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : AdminBaseController
    {
        ProductTypeDAL prTypeDAL;
        public LoaiSanPhamController()
        {
            prTypeDAL = new ProductTypeDAL();
        }
        public ActionResult DanhSachLoaiSanPham()
        {
            var dssp = prTypeDAL.GetAll();
            return View(dssp);
        }
        [HttpGet]
        public ActionResult ThemMoiLSP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiLSP(ProductType pro)
        {
            if (pro != null)
            {
                prTypeDAL.Add(pro);
            }
            return RedirectToAction("DanhSachLoaiSanPham");
        }
        public ActionResult Xoa(string name)
        {
            if (name != null)
            {
                prTypeDAL.Delete(name);
            }
            return RedirectToAction("DanhSachLoaiSanPham");
        }
        [HttpGet]
        public ActionResult Sua(string name)
        {
            var type = prTypeDAL.GetByName(name);
            return View(type);
        }
        [HttpPost]
        public ActionResult Sua(ProductType pro)
        {
            prTypeDAL.Update(pro);
            return RedirectToAction("DanhSachLoaiSanPham");
        }
    }
}