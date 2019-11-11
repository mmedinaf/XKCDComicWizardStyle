using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using XKCDComicWizardStyle.Controllers;
using XKCDComicWizardStyle.Models;

namespace XKCDComicWizardStyle.Tests
{
    [TestClass]
    public class NextEmpty
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                APIClient cliente = new APIClient();
                int comicNumber = 404; //comic number 404 is empty
                Comic comic = cliente.GetComic(comicNumber);

                // The resultant Comic should be the next existing Comic, in this case 405
                Assert.Equals(comic.Num, 505);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
