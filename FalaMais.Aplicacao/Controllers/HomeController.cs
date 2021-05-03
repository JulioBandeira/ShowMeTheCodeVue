using FalaMais.Aplicacao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FalaMais.Aplicacao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPrecoLigacaoServices _iprecoLigacaoServices;
       
        public HomeController(ILogger<HomeController> logger, IPrecoLigacaoServices iprecoLigacaoServices)
        {
            _logger = logger;
            _iprecoLigacaoServices = iprecoLigacaoServices;
        }

        public IActionResult Index()
        {
            return View();
        }

     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
