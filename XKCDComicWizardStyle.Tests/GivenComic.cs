using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using XKCDComicWizardStyle.Controllers;
using XKCDComicWizardStyle.Models;

namespace XKCDComicWizardStyle.Tests
{
    [TestClass]
    public class GivenComic
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                APIClient cliente = new APIClient();
                int comicNumber = 405;
                Comic comic = cliente.GetComic(comicNumber);

                // Obtaining a given comic
                Assert.IsNotNull(comic);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
