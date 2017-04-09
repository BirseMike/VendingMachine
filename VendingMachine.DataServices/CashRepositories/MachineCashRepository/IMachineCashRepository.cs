using System.Collections.Generic;
using System.Threading.Tasks;

namespace VendingMachine.DataServices.CashRepositories
{
    public interface IMachineCashRepository : ICashRepository
    {
        Task<bool> HasChange(double value);
        IEnumerable<KeyValuePair<Demonination,int>> giveChange(double value);
    }
}
