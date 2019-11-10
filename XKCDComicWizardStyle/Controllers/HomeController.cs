using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XKCDComicWizardStyle.Models;

namespace XKCDComicWizardStyle.Controllers
{
    public class HomeController : Controller
    {
        private APIClient cliente;
        public IActionResult Index(int? id)
        {
            if (cliente == null)
                cliente = new APIClient();

            int indiceComic = 0;
            if (id.HasValue)
                indiceComic = id.Value;
            Comic comicDelDia = cliente.GetComic(indiceComic);
            ViewBag.Position = comicDelDia;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
