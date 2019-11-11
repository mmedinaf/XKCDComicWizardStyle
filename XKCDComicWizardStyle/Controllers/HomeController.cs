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
        private APIClient client;
        private int lastNum;
        public IActionResult Index(int? id, bool? previous)
        {
            if (client == null)
                client = new APIClient();

            int comicIndex = 0;
            // Define last comic with most recent comic's number
            if (lastNum < 1)
            {
                lastNum = client.GetComic(0).Num;
                ViewBag.Settings = lastNum;
            }
            
            if (id.HasValue)
                comicIndex = id.Value;
            Comic returnedComic = client.GetComic(comicIndex);
            ViewBag.Position = returnedComic;
            if (!id.HasValue)
                comicIndex = returnedComic.Num;

            //indexResult will be null in case of returning an empty comic
            var indexResult = ((Comic)ViewBag.Position).Num;
            //In case of a null Index Result, go to the previos comic until getting a valid comic
            if (indexResult != comicIndex)
            {
                //Setting the index for previous comic
                indexResult = (previous ?? false ? comicIndex - 1 : indexResult);
                return Redirect("/Home/Index/" + indexResult);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
