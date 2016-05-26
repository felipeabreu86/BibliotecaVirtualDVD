using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaVirtualdeDVDs.Models;

namespace BibliotecaVirtualdeDVDs.ActionFilters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User Usuario = (User)filterContext.HttpContext.Session["user"];

            if (Usuario != null)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/Login/Login");
            }            
        }
    }
}