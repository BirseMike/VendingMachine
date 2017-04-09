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
                new Product { Id = 1, Name = "banana", Price = 0.5M, Stock = 10 },
                new Product { Id = 2, Name = "apple", Price = 0.5M, Stock = 10 },
                new Product { Id = 3, Name = "kiwi", Price = 1, Stock = 10 },
                new Product { Id = 4, Name = "orange", Price = 1.5M, Stock = 10 },
                new Product { Id = 5, Name = "strawberry", Price = 0.25M, Stock = 10 },
                new Product { Id = 6, Name = "raspberry", Price = 0.15M, Stock = 10 },
                new Product { Id = 7, Name = "mango", Price = 0.45M, Stock = 10 },
                new Product { Id = 8, Name = "persimmons", Price = 2M, Stock = 10 },
                new Product { Id = 9, Name = "papaya", Price = 2.5M, Stock = 10 },
                new Product { Id = 10, Name = "blueberry", Price = 0.40M, Stock = 10 }
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
    }
}
