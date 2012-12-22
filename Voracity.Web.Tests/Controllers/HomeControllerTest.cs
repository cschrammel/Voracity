using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voracity.Web.Controllers;

namespace Voracity.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Voracity", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Play()
        {
            var controller = new HomeController();
            var result = controller.Play() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}