using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using BibliotecaVirtualdeDVDs.ActionFilters;

namespace BibliotecaVirtualdeDVDs.Controllers
{
    [LoginFilter]
    public class HomeController : BaseController
    {
        [OutputCache(Duration = 15, VaryByParam = "cacheIndex")]
        public ActionResult Index()
        {
            // Retorna a view Index
            return View();
        }

        public ActionResult SetIdioma()
        {
            // Armazena o conteúdo do elemento culture passado via URL
            string Culture = Request.QueryString.Get("culture");

            // Se o conteúdo de culture não for vazio, armazenar na Session
            if (Culture != null)
            {
                Session["culture"] = Culture;
            }

            // Retorna a view Index
            return View("Index");
        }
    }
}