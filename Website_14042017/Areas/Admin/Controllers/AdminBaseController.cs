using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session["accAdmin"];
            if(session == null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new {
                                controller = "Login",
                                action = "Index", Area="admin"
                            })
                        );
            }
            base.OnActionExecuting(filterContext);
        }
    }
}