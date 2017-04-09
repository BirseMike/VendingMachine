namespace VendingMachine.DataServices.CashRepository
{
    public interface ICustomerCashRepository : ICashRepository
    {
        void Empty();
    }
}
