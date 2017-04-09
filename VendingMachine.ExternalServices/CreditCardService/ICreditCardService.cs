using System.Threading.Tasks;

namespace VendingMachine.ExternalServices
{
    public interface ICreditCardService
    {
        Task<bool> IsCardValid(string creditCardNumber);
        Task<bool> PaymentAccepted(string creditCardNumber);

    }
}