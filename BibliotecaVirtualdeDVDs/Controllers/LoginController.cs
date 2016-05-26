using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaVirtualdeDVDs.Models;

namespace BibliotecaVirtualdeDVDs.Controllers
{
    public class LoginController : Controller
    {
        private User UsuarioAutorizado;

        public LoginController()
        {
            UsuarioAutorizado = new User();
            UsuarioAutorizado.email = "email@email.com";
            UsuarioAutorizado.password = "123";
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Email = UsuarioAutorizado.email;
            ViewBag.Senha = UsuarioAutorizado.password;

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User Usuario)
        {
            // Verifica se o usuário é válido
            if(!UsuarioAutorizado.Equals(Usuario))
            {
                ModelState.AddModelError("User", "Usuário incorreto");
            }

            // Validate model
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            Session["user"] = Usuario;
            return RedirectToAction("Index", "Home");
        }

    }
}
