namespace VendingMachine.DataServices
{ 
    public interface ICashRepository
    {
        bool Add(Demonination denomination);
        bool GiveChange(double value);
        bool HasChange(double value);
    }
}
