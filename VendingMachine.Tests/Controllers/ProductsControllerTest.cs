namespace VendingMachine.Tests.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using VendingMachine.Controllers;

    [TestClass]
    public class ProductsControllerTest
    {
        private Mock<IProductRepository> productRepository;

        [TestInitialize]
        public void Initialize()
        {
            this.productRepository = new Mock<IProductRepository>();
        }

        [TestMethod]
        public async Task Get_ActionInvoked_ProductRepositoryCalled()
        {
            // Arrange
            ProductsController controller = GetController();

            // Act
            await controller.GetAsync();

            // Assert
            productRepository.Verify(pr => pr.GetAllProducts());
        }

        [TestMethod]
        public async Task GetById_ValidIdPassedAndFound_ProductRepositoryCalledWithCorrectId()
        {
            // Arrange
            ProductsController controller = GetController();
            const int ProductId = 5;
            SetupProductService(new Product { Stock = 1 });

            // Act
            await controller.GetAsync(ProductId);

            // Assert
            productRepository.Verify(pr => pr.GetProduct(ProductId));
        }

        private ProductsController GetController()
        {
            return new ProductsController(productRepository.Object);
        }

        private void SetupProductService(Product product = null)
        {
            productRepository.Setup(pr => pr.GetProduct(It.IsAny<int>()))
                .Returns(async () => {
                    await Task.Yield();
                    return product;
                });
        }
    }
}
