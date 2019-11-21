using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using ShirtStoreWebsite.Controllers;
using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;
using ShirtStoreWebsite.Tests.FakeRepositories;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;


namespace ShirtStoreWebsite.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ShirtControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllShirts()
        {
            var fakeShirtReopistory = new FakeShirtRepository();
            var mocklogger = new Mock<ILogger<ShirtController>>();
            var shirtController = new ShirtController(fakeShirtReopistory, mocklogger.Object);
            var viewResult = shirtController.Index() as ViewResult;
            var shirts = viewResult.Model as List<Shirt>;
            Assert.AreEqual(3, shirts.Count);
        }
    }
}
