using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;

namespace BibliotecaVirtualdeDVDs.Controllers
{
    public class BaseController : Controller
    {
        // Método invocado DEPOIS da execução da Action
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Armazena o conteúdo contido na Session culture
            string Culture = (string)Session["culture"];

            // Se houver valor armazenado na Session
            if (Culture != null)
            {
                try
                {
                    // Tentar configurar a culture que estava armazenada na Session
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Culture);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(Culture);
                }
                catch
                {
                    // Se não conseguir, limpar a configuração da culture
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }

            base.OnActionExecuted(filterContext);
        }

    }
}
