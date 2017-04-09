using System.Threading.Tasks;

namespace VendingMachine.DataServices
{ 
    public interface ICashRepository
    {
        Task<double> Add(Demonination denomination);
    }


}
