namespace VendingMachine.DataServices.CashRepository
{
    public interface IMachineCashRepository : ICashRepository
    {
        bool HasChange(double value);
        dynamic giveChange(double value);
    }
}
