using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notenet.Web.Desktop;
using Notenet.Web.Desktop.Controllers;

namespace Notenet.Web.Desktop.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        /*
        [TestMethod]
        public void Index()
        {
            // Arrange
            CoverController controller = new CoverController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
        }
         * */

        [TestMethod]
        public void About()
        {
            // Arrange
            CoverController controller = new CoverController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
