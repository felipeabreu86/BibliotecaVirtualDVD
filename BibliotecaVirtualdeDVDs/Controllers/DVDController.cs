using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaVirtualdeDVDs.Models;
using BibliotecaVirtualdeDVDs.ActionFilters;

namespace BibliotecaVirtualdeDVDs.Controllers
{
    [LoginFilter]
    public class DVDController : BaseController
    {
        private static List<DVD> DvdsCadastrados = new List<DVD>();

        [HttpGet]
        public ActionResult Adicionar()
        {
            // Retorna a view Adicionar
            return View();
        }
        
        [HttpPost]
        public ActionResult Adicionar(DVD Dvd)
        {
            // Validar se o Estado do Modelo é válido
            if (!ModelState.IsValid)
            {
                // Retorna a view referente à página de erro
                return View("Erro");
            }

            // Adiciona o DVD à lista de DVDs cadastrados
            DvdsCadastrados.Add(Dvd);
            
            // Retorna View Sucesso e passa o Modelo para ser exibido
            return View("Sucesso", Dvd);
        }

        [HttpGet]
        public ActionResult ListarDvds()
        {
            // Retorna a view ListarDvds passando a lista de DVDs cadastrados
            return View("ListarDvds", DvdsCadastrados);
        }

        [HttpGet]
        public ActionResult ConfiguracoesUsuario()
        {
            // Retorna a view com as opções de configuração do usuário
            return View();
        }
        
        [HttpPost]
        public ActionResult ConfiguracoesUsuario(FormCollection form)
        {
            // Armazenar, separando por vírgulas, todos os Values dos Inputs com o nome AtributosDvd do formulário
            string Param = form["AtributosDvd"];

            // Limpar os atributos Session de configurações do usuário
            Session.Remove("ExibirTitulo");
            Session.Remove("ExibirAno");
            Session.Remove("ExibirGenero");

            // Verificar se houve alteração nas configurações do usuário
            if (Param != null)
            {
                // Armazenar os Values em um Array
                string[] Atributos = Param.Split(',');

                // Para cada Value, atualizar um Session com o seu nome para True
                foreach (string Atributo in Atributos)
                {
                    Session[Atributo] = true;
                }
            }

            // Redirecionar para a View Listar DVDs
            return RedirectToAction("ListarDvds");
        }
        
        [HttpPost]
        public ActionResult Apagar(DVD Dvd) {
            // Set view dvd
            ViewBag.DvdExcluido = Dvd;

            // Remove dvd
            DvdsCadastrados.Remove(Dvd);

            // Return pview
            return PartialView("_ListarDvdsContent", DvdsCadastrados);
        }

    } // Fim da classe DVDController
}