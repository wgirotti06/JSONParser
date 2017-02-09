using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONParser.Web;
using JSONParser.Web.Controllers;
using System.Web;
using System.IO;
using Moq;
using System.Configuration;

namespace JSONParser.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Results()
        {
            // Arrange
            HomeController controller = new HomeController();

            string path = ConfigurationManager.AppSettings["FilePath"];
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Mock<HttpPostedFileBase> uploadedFile = new Mock<HttpPostedFileBase>();

            uploadedFile.Setup(x => x.FileName).Returns(fileStream.Name);
            uploadedFile.Setup(x => x.ContentLength).Returns((int)fileStream.Length);
            uploadedFile.Setup(x => x.InputStream).Returns(fileStream);

            // Act
            ViewResult result = controller.Results(uploadedFile.Object) as ViewResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }
    }
}
