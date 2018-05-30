using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtClubFinal;
using ArtClubFinal.Controllers;

namespace ArtClubFinal.Tests.Controllers
{
    [TestClass]
    public class MembersControllerTest
    {
        [TestMethod]
        public void Index_Members_ReturnsIndexView()
        {
            // Arrange
            MembersController controller = new MembersController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GuestIndex()
        {
            // Arrange
            MembersController controller = new MembersController();

            // Act
            ViewResult result = controller.GuestIndex() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
