namespace VendingMachine.DataServices
{
    using System;
    using System.Collections.Generic;

     class CashRepository : ICashRepository
    {
        protected Dictionary<Demonination,int> DenominationBalances;

        public CashRepository()
        {
            DenominationBalances = new Dictionary<Demonination, int>();
        }

        public void Add(Demonination denomination)
        {
            DenominationBalances[denomination] = DenominationBalances[denomination] + 1;
        }

        public void Initialise(int Count)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Demonination denomination)
        {
            bool canRemove = DenominationBalances[denomination] > 0;
            if (canRemove)
            {
                DenominationBalances[denomination] = DenominationBalances[denomination] - 1;
            }
            return canRemove;
        }

        /*

                  //initialise the cash in the machine
                   foreach (var denom in Enum.GetValues(typeof(Demonination)))
                   {
                       DenominationBalances.Add((Demonination)denom, 5);
                   }
                */
    }
}
