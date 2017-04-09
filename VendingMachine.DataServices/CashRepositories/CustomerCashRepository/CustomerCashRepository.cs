using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VendingMachine.DataServices.CashRepositories
{
    public class CustomerCashRepository : ICustomerCashRepository
    {
        private Dictionary<Demonination, int> cashBalances;

        public CustomerCashRepository()
        {
            cashBalances = new Dictionary<Demonination, int>();
        }

        public async Task<double> Add(Demonination denomination)
        {
            return await Task.Run(() =>
           {
               if (cashBalances.ContainsKey(denomination))
               {
                   cashBalances[denomination] = cashBalances[denomination] + 1;
               }
               else
               {
                   cashBalances.Add(denomination, 1);
               }

               return cashBalances.GetBalanceSum();
           });
        }

        public async Task<double> GetCurrentBalance()
        {
            return await Task.Run(() => cashBalances.GetBalanceSum());
        }

        //TODO correctly implement the transfer from customer to machine

        public Dictionary<Demonination, int> GetCash()
        {
            return new Dictionary<Demonination, int>(cashBalances);
        }

        public Dictionary<Demonination, int> RefundAll()
        {
            var refunds = new Dictionary<Demonination, int>(cashBalances);
            cashBalances.Clear();
            return refunds;
        }
    }
}
