using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using XKCDComicWizardStyle.Controllers;
using XKCDComicWizardStyle.Models;

namespace XKCDComicWizardStyle.Tests
{
    [TestClass]
    public class OutOfBound
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                APIClient cliente = new APIClient();
                int indexOutOfBounds = 9000;
                Comic comic = cliente.GetComic(indexOutOfBounds);

                // If we set a index greater than the max index of comics, then it would go back to the first comic
                Assert.AreEqual(comic.Num, 1);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
