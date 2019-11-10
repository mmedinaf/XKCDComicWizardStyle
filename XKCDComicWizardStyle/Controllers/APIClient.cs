using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using XKCDComicWizardStyle.Models;

namespace XKCDComicWizardStyle.Controllers
{
    public class APIClient
    {
        public Comic GetComic(int indiceComic)
        {
            var cadena = "";
            using (WebClient cliente = new WebClient())
            {
                string ruta = "";
                
                if(indiceComic == 0)
                    ruta = "https://xkcd.com/info.0.json";

                try
                {
                    cadena = cliente.DownloadString(ruta);
                }
                catch (WebException ex)
                {
                    throw ex;
                }
                    
            }

            if (cadena.Length > 0)
                return JsonConvert.DeserializeObject<Comic>(cadena);
            return new Comic();
        }
    }
}
