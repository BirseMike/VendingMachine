namespace VendingMachine.DataServices
{ 
    public interface ICashRepository
    {
        void Add(Demonination denomination);
        bool Remove(Demonination denomination);
    }


}
