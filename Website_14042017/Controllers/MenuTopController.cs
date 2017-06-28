using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_14042017.DAL;

namespace Website_14042017.Controllers
{
    public class MenuTopController : Controller
    {
        MenuDAL menuDAL;
        ProductTypeDAL prTypeDAL;
        ProductDAL prDAL;
        public MenuTopController()
        {
            menuDAL = new MenuDAL();
            prTypeDAL = new ProductTypeDAL();
            prDAL = new ProductDAL();
        }
        public ActionResult GenerateMenu()
        {
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
                            menu += "<li class='dropdown'>"
                                 + "<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false'>" + item0.DisplayName + "<span class='caret'></span></a>"
                                 + "<ul class='dropdown-menu'>";
                            if (menu1 != null)
                                foreach (var item1 in menu1)
                                {
                                    if (item1.IdMenuLevel0 == item0.Name)
                                    {
                                        menu += "<li>"
                                            + "<a href ='" + item1.Link + "'> " + item1.DisplayName + "</a>"
                                            + "</li >";
                                    }
                                }
                            menu += "</ul></li>";

                        }
                        else
                        {
                            menu += " <li class='dropdown'>"
                                   + "<a href ='" + item0.Link + "'>" + item0.DisplayName + "</a>"
                                    + "</li>";
                        }
                    }
                return Content(menu);
            }
            catch
            {
                return Content(menu);
            }
        }
        public ActionResult MenuLeftType()
        {
            var types = prTypeDAL.GetAll();
            var pr = prDAL.GetAll();
            string menu = "";
            try
            {
                if (types != null)
                    foreach (var item in types)
                    {
                        menu += "<li><span class='glyphicon glyphicon-triangle-right'></span>  <a href='#'>" + item.Name.ToUpper() + "</a>";
                        menu += "<ul>";
                        if (pr != null)
                            foreach (var itemnext in pr)
                            {
                                if (itemnext.ProductType == item.Name)
                                    menu += "<li><span class='glyphicon glyphicon-triangle-right'></span>  <a href='/product/productdetails?name=" + itemnext.Name + "'>" + itemnext.Name + "</a></li>";
                            }
                        menu += "</ul>";
                        menu += "</li>";
                    }
                return Content(menu);
            }
            catch
            {
                return Content(menu);
            }
        }
    }
}