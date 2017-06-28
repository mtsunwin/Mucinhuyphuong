using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class MenuController : AdminBaseController
    {
        MenuDAL menuDAL;
        public MenuController()
        {
            menuDAL = new MenuDAL();
        }
        //Menu level 0
        [HttpGet]
        public ActionResult MenuLevel0()
        {
            var menus = menuDAL.GetAllMenu0();
            return View(menus);
        }
        [HttpPost]
        public ActionResult PostMenu0(MenuLevel0 menu)
        {
            if (ModelState.IsValid)
            {
                if (menu != null)
                {
                    try
                    {
                        menuDAL.CreateMenu0(menu);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.MessageAddMenu0 = ex.Message;
                        var menus = menuDAL.GetAllMenu0();
                        ViewBag.Model = menu;
                        return View("MenuLevel0", menus);
                    }
                }
            }
            return RedirectToAction("MenuLevel0");
        }
        [HttpPost]
        public ActionResult PostEditMenu0(MenuLevel0 menu)
        {
            if (ModelState.IsValid)
            {
                if (menu != null)
                {
                    try
                    {
                        menuDAL.UpDateMenu0(menu);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.MessageEditMenu0 = ex.Message;
                        var menus = menuDAL.GetAllMenu0();
                        return View("MenuLevel0", menus);
                    }
                }
            }
            return RedirectToAction("MenuLevel0");
        }
        public ActionResult DeleteMenu0(string name)
        {
            if (string.IsNullOrEmpty(name) || name != null)
            {
                try
                {
                    menuDAL.DeleteMenu0(name);
                }
                catch (Exception ex)
                {
                    ViewBag.MessageDeleteMenu0 = ex.Message;
                    var menus = menuDAL.GetAllMenu0();
                    return View("MenuLevel0", menus);
                }
            }
            return RedirectToAction("MenuLevel0");
        }

        //Menu level 1
        [HttpGet]
        public ActionResult MenuLevel1(string idMenu0)
        {
            ViewBag.Focus = idMenu0;
            var menu0s = menuDAL.GetAllMenu0();
            ViewBag.Menu0s = menu0s;
            var menu1s = menuDAL.GetAllMenu1();
            return View(menu1s);
        }
        [HttpPost]
        public ActionResult PostMenu1(MenuLevel1 menu)
        {
            if (ModelState.IsValid)
            {
                if (menu != null)
                {
                    try
                    {
                        var mn = menuDAL.GetByDisplayNameMenu1(menu.DisplayName);
                        if (mn != null)
                        {
                            ViewBag.ModelMenu1 = menu;
                            ViewBag.MessageAddMenu1 = "Tên này đã dùng.";
                            var menu0s = menuDAL.GetAllMenu0();
                            ViewBag.Menu0s = menu0s;
                            var menu1s = menuDAL.GetAllMenu1();
                            return View("MenuLevel1", menu1s);
                        }
                        menuDAL.CreateMenu1(menu);
                        ViewBag.Focus = menu.IdMenuLevel0;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ModelMenu1 = menu;
                        ViewBag.MessageAddMenu1 = ex.Message;
                        ViewBag.Focus = menu.IdMenuLevel0;
                        var menu0s = menuDAL.GetAllMenu0();
                        ViewBag.Menu0s = menu0s;
                        var menu1s = menuDAL.GetAllMenu1();
                        return View("MenuLevel1", menu1s);
                    }
                }
            }
            return Redirect("/admin/menu/MenuLevel1?idMenu0=" + menu.IdMenuLevel0);
        }
        public ActionResult DeleteMenu1(int id, string idMenu0)
        {
            try
            {
                menuDAL.DeleteMenu1(id);
            }
            catch (Exception ex)
            {
                ViewBag.MessageDeleteMenu1 = ex.Message;
                ViewBag.Focus = idMenu0;
                var menu0s = menuDAL.GetAllMenu0();
                ViewBag.Menu0s = menu0s;
                var menu1s = menuDAL.GetAllMenu1();
                return View("MenuLevel1", menu1s);
            }
            return Redirect("/admin/menu/MenuLevel1?idMenu0=" + idMenu0);
        }
        [HttpPost]
        public ActionResult PostEditMenu1(MenuLevel1 menu)
        {
            if (ModelState.IsValid)
            {
                if (menu != null)
                {
                    try
                    {
                        menuDAL.UpDateMenu1(menu);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.MessageEditMenu1 = ex.Message;
                        ViewBag.Focus = menu.IdMenuLevel0;
                        var menus = menuDAL.GetAllMenu1();
                        return View("MenuLevel1", menus);
                    }
                }
            }
            return Redirect("/admin/menu/MenuLevel1?idMenu0=" + menu.IdMenuLevel0);
        }

        //Menu level 2
        [HttpGet]
        public ActionResult MenuLevel2(int? idMenu1, string idMenu0)
        {
            ViewBag.FocusM0 = idMenu0;
            ViewBag.FocusM1 = idMenu1;
            var menu0s = menuDAL.GetAllMenu0();
            var menu1s = menuDAL.GetAllMenu1();
            ViewBag.Menu0s = menu0s;
            ViewBag.Menu1s = menu1s;
            var menu2s = menuDAL.GetAllMenu2();
            return View(menu2s);
        }
        [HttpPost]
        public ActionResult PostMenu2(MenuLevel2 menu, string idMenu0)
        {
            if (ModelState.IsValid)
            {
                if (menu != null)
                {
                    try
                    {
                        var mn = menuDAL.GetByDisplayNameMenu2(menu.DisplayName.Trim(),menu.IdMenuLevel1);
                        if (mn != null)
                        {
                            ViewBag.ModelMenu2 = menu;
                            ViewBag.MessageAddMenu2 = "Tên này đã dùng.";
                            var menu0s = menuDAL.GetAllMenu0();
                            var menu1s = menuDAL.GetAllMenu1();
                            ViewBag.Menu0s = menu0s;
                            ViewBag.Menu1s = menu1s;
                            var menu2s = menuDAL.GetAllMenu2();
                            return View("MenuLevel2", menu2s);
                        }
                        menuDAL.CreateMenu2(menu);
                        ViewBag.FocusM0 = idMenu0;
                        ViewBag.FocusM1 = menu.IdMenuLevel1;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ModelMenu2 = menu;
                        ViewBag.MessageAddMenu2 = ex.Message;
                        var menu0s = menuDAL.GetAllMenu0();
                        var menu1s = menuDAL.GetAllMenu1();
                        ViewBag.Menu0s = menu0s;
                        ViewBag.Menu1s = menu1s;
                        var menu2s = menuDAL.GetAllMenu2();
                        return View("MenuLevel2", menu2s);
                    }
                }
            }
            return Redirect("/admin/menu/MenuLevel2?idMenu0=" + idMenu0 + "&idMenu1=" + menu.IdMenuLevel1);
        }
        [HttpPost]
        public ActionResult PostEditMenu2(MenuLevel2 menu, string idMenu0Edit)
        {
            if (ModelState.IsValid)
            {
                if (menu != null)
                {
                    try
                    {
                        var mn = menuDAL.GetByDisplayNameMenu2(menu.DisplayName.Trim(), menu.IdMenuLevel1);
                        if (mn != null)
                        {
                            ViewBag.ModelMenu2 = menu;
                            ViewBag.MessageEditMenu2 = "Tên này đã dùng.";
                            var menu0s = menuDAL.GetAllMenu0();
                            var menu1s = menuDAL.GetAllMenu1();
                            ViewBag.Menu0s = menu0s;
                            ViewBag.Menu1s = menu1s;
                            var menu2s = menuDAL.GetAllMenu2();
                            return View("MenuLevel2", menu2s);
                        }
                        menuDAL.UpDateMenu2(menu);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ModelMenu2 = menu;
                        ViewBag.MessageEditMenu2 = ex.Message;
                        var menu0s = menuDAL.GetAllMenu0();
                        var menu1s = menuDAL.GetAllMenu1();
                        ViewBag.Menu0s = menu0s;
                        ViewBag.Menu1s = menu1s;
                        var menu2s = menuDAL.GetAllMenu2();
                        var menus = menuDAL.GetAllMenu1();
                        return View("MenuLevel1", menus);
                    }
                }
            }
            return Redirect("/admin/menu/MenuLevel2?idMenu0=" + idMenu0Edit + "&idMenu1=" + menu.IdMenuLevel1);
        }
        public ActionResult DeleteMenu2(int id, string idMenu0, int? idMenu1)
        {
            try
            {
                menuDAL.DeleteMenu2(id);
            }
            catch (Exception ex)
            {
                ViewBag.MessageDeleteMenu2 = ex.Message;
                var menu0s = menuDAL.GetAllMenu0();
                var menu1s = menuDAL.GetAllMenu1();
                ViewBag.Menu0s = menu0s;
                ViewBag.Menu1s = menu1s;
                var menu2s = menuDAL.GetAllMenu2();
                var menus = menuDAL.GetAllMenu1();
                return View("MenuLevel2", menu2s);
            }
            return Redirect("/admin/menu/MenuLevel2?idMenu0=" + idMenu0 + "&idMenu1=" + idMenu1);
        }
    }
}