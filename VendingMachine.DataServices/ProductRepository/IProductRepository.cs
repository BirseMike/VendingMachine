namespace VendingMachine.DataServices
{
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<Product[]> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<Product> BuyProduct(int id);
    }

}