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

        public Comic GetComic(int comicIndex)
        {
            int infinityValidation = 0;
            string stringJSON = "";
            using (WebClient cliente = new WebClient())
            {
                bool validComic = true;
                do
                {
                    string link = comicIndex == 0 ?
                    //Setting initial link [https://xkcd.com/info.0.json]
                    $"{BaseDomain}{BaseJson}" :
                    //Setting a given comic [https://xkcd.com/404/info.0.json]
                    $"{BaseDomain}/{comicIndex}/{BaseJson}";
                    // Searching a valid comic
                    try
                    {
                        stringJSON = cliente.DownloadString(link);
                        validComic = true;
                    }
                    catch (WebException)
                    {
                        validComic = false;
                        comicIndex++;
                        infinityValidation++;
                    }
                    // Avoiding out of bound
                    if (infinityValidation >= 4)
                    {
                        comicIndex = 1;
                    }
                } while (!validComic);
            }

            //Getting the valid comic
            if (stringJSON.Length > 0)
                return JsonConvert.DeserializeObject<Comic>(stringJSON);
            return new Comic();
        }
    }
}
