namespace VendingMachine.DataServices.CashRepository.MachineCashRepository
{
    using System;
    using System.Collections.Generic;

    class MachineCashRepository : IMachineCashRepository
    {
        protected Dictionary<Demonination, int> DenominationBalances;
        public MachineCashRepository()
        {

            //initialise the cash in the machine
            foreach (var denom in Enum.GetValues(typeof(Demonination)))
            {
                DenominationBalances.Add((Demonination)denom, 5);
            }
        }

        public void Add(Demonination denomination)
        {
            throw new NotImplementedException();
        }

        public dynamic giveChange(double value)
        {
            throw new NotImplementedException();
        }

        public bool HasChange(double value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Demonination denomination)
        {
            throw new NotImplementedException();
        }
    }
}
