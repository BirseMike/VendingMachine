using System.Collections.Generic;
using System.Threading.Tasks;

namespace VendingMachine.DataServices.CashRepositories
{
    public interface ICustomerCashRepository : ICashRepository
    {
        Task<double> GetCurrentBalance();
        Dictionary<Demonination, int> GetCash();
        Task<Dictionary<Demonination, int>> RefundAll();
    }
}
