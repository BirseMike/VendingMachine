using System.Collections.Generic;

namespace VendingMachine.DataServices.CashRepositories
{
    public interface IMachineCashRepository : ICashRepository
    {
        bool HasChange(double value);
        IEnumerable<KeyValuePair<Demonination,int>> giveChange(double value);
    }
}
