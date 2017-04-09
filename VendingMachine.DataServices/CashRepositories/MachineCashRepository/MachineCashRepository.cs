namespace VendingMachine.DataServices.CashRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MachineCashRepository : IMachineCashRepository
    {
        protected Dictionary<Demonination, int> machineBalances;
        public MachineCashRepository()
        {
            machineBalances = new Dictionary<Demonination, int>();

            //initialise the cash in the machine
            foreach (var denom in Enum.GetValues(typeof(Demonination)))
            {
                machineBalances.Add((Demonination)denom, 5);
            }
        }

        public async Task<double> Add(Demonination denomination)
        {
            return await Task.Run(() =>
            {
                machineBalances[denomination] = machineBalances[denomination] + 1;
                return machineBalances.GetBalanceSum();
            });
        }

        public async Task<bool> HasChange(double value)
        {
            return await Task.Run(() =>
            {
                return machineBalances.IsSufficient(value);
            });
        }

        public IEnumerable<KeyValuePair<Demonination, int>> giveChange(double value)
        {
            throw new NotImplementedException();
        }

        
    }
}
