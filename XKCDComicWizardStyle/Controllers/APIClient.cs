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
        private const string BaseDomain = "https://xkcd.com/";
        private const string BaseJson = "info.0.json";

        public Comic GetComic(int indiceComic)
        {
            var cadena = "";
            using (WebClient cliente = new WebClient())
            {
                string ruta = BaseDomain;
                if (indiceComic < 1)
                    ruta += BaseJson;
                else
                    ruta += "/" + indiceComic + "/" + BaseJson;

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
