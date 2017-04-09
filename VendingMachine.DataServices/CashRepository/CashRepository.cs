namespace VendingMachine.DataServices
{
    using System;

    public class CashRepository : ICashRepository
    {
        public bool Add(Demonination denomination)
        {
            throw new NotImplementedException();
        }

        public bool GiveChange(double value)
        {
            throw new NotImplementedException();
        }

        public bool HasChange(double value)
        {
            throw new NotImplementedException();
        }
    }
}
