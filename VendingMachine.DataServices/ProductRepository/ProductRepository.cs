namespace VendingMachine.DataServices
{
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductRepository : IProductRepository
    {
        Product[] products;

        public ProductRepository()
        {
            products = new Product[]
            {
                new Product { Id = 101, Name = "banana", Price = 0.5M, Stock = 5 },
                new Product { Id = 201, Name = "apple", Price = 0.5M, Stock = 5 },
                new Product { Id = 301, Name = "kiwi", Price = 1, Stock = 5 },
                new Product { Id = 401, Name = "orange", Price = 1.5M, Stock = 5 },
                new Product { Id = 501, Name = "strawberry", Price = 0.25M, Stock = 5 },
                new Product { Id = 601, Name = "raspberry", Price = 0.15M, Stock = 5 },
                new Product { Id = 701, Name = "mango", Price = 0.45M, Stock = 5 },
                new Product { Id = 808, Name = "persimmons", Price = 2M, Stock = 5 },
                new Product { Id = 909, Name = "papaya", Price = 2.5M, Stock = 5 },
                new Product { Id = 109, Name = "blueberry", Price = 0.40M, Stock = 5 }
            };

        }

        public async Task<Product[]> GetAllProducts()
        {
            return await Task.Run(() => products);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await Task.Run(() => products.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Product> BuyProduct(int id)
        {
            var product = await Task.Run(() => products.FirstOrDefault(p => p.Id == id));
            if (product!=null)
            {
                if (product.Stock > 0)
                {
                    product.Stock--;
                }
                else
                {
                    throw new System.Exception($"Product {id} out of stock");
                }
            }

            if (product == null)
            {
                throw new System.Exception($"Product {id} not found");
            }
            return product;
        }
    }
}
