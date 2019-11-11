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
        private int lastNum;
        public IActionResult Index(int? id)
        {
            if (cliente == null)
                cliente = new APIClient();

            // Define last comic with most recent comic's number
            if (lastNum < 1)
            {
                lastNum = cliente.GetComic(0).Num;
                ViewBag.Settings = lastNum;
            }

            int indiceComic = 0;
            if (id.HasValue)
                indiceComic = id.Value;
            Comic comicObtenido = cliente.GetComic(indiceComic);
            ViewBag.Position = comicObtenido;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
