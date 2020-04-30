using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsultaDisparos.Models;

namespace ConsultaDisparos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisparosErroSemProcesso()
        {
            DisparosErroSemProcessoContext context = HttpContext.RequestServices.GetService(typeof(ConsultaDisparos.Models.DisparosErroSemProcessoContext)) as DisparosErroSemProcessoContext;

            return View(context.GetAllErroSemProcesso());
        }

        public IActionResult DisparosErroSemAssociacao()
        {
            DisparosErroSemAssociacaoContext context = HttpContext.RequestServices.GetService(typeof(ConsultaDisparos.Models.DisparosErroSemAssociacaoContext)) as DisparosErroSemAssociacaoContext;

            return View(context.GetAllErroSemAssociacao());
        }

        public IActionResult DisparosErroSemProcessoFlgDisparadoZero()
        {
            DisparosErroSemProcessoFlgDisparadoZeroContext context = HttpContext.RequestServices.GetService(typeof(ConsultaDisparos.Models.DisparosErroSemProcessoFlgDisparadoZeroContext)) as DisparosErroSemProcessoFlgDisparadoZeroContext;

            return View(context.GetAllErroProcessoFlgDisparadoZerado());
        }

        public IActionResult DisparosErroSemAssociacaoFlgDisparadoZero()
        {
            DisparosErroSemAssociacaoFlgDisparadoZeroContext context = HttpContext.RequestServices.GetService(typeof(ConsultaDisparos.Models.DisparosErroSemAssociacaoFlgDisparadoZeroContext)) as DisparosErroSemAssociacaoFlgDisparadoZeroContext;

            return View(context.GetAllErroAssociacaoFlgDisparadoZerado());
        }

        public IActionResult DisparosErroEnfileiramento()
        {
            DisparosErroEnfileiramentoContext context = HttpContext.RequestServices.GetService(typeof(ConsultaDisparos.Models.DisparosErroEnfileiramentoContext)) as DisparosErroEnfileiramentoContext;

            return View(context.GetAllErroEnfileiramento());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
