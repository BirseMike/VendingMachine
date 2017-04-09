namespace VendingMachine.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Models;
    using VendingMachine.DataServices;

    public class ProductsController : ApiController
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET api/values
        public async Task<IEnumerable<Product>> GetAsync()
        {
            var products = await productRepository.GetAllProducts();

            return products;
        }

        // GET api/values/5
        public async Task<Product> GetAsync(int id)
        {
            var product = await productRepository.GetProduct(id);

            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"Invalid Product Code : {id}"),
                    ReasonPhrase = "Product Code Not Found"
                };

                throw new HttpResponseException(resp);
            }

            if (product.Stock<=0)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Product {id} - Out Of Stock"),
                    ReasonPhrase = "Product Out of Stock"
                };

                throw new HttpResponseException(resp);
            }

            return product;
        }
    }

}
