using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.WEB.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View(); //_repository.ListarProdutos()
        }

        public string Obter()
        {
            return "Feliz Ano Novo";
        }
    }
}
