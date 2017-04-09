namespace VendingMachine.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VendingMachine.Controllers;

    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ProductsController controller = new ProductsController(null);

            // Act
            IEnumerable<string> result = null;//controller.GetAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ProductsController controller = new ProductsController(null);

            // Act
            var result = controller.GetAsync(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public async void Post()
        {
            // Arrange
            ProductsController controller = new ProductsController(null);

            // Act
            await controller.Post(null);

            // Assert
        }


    }
}
