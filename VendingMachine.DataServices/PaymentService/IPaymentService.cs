using System.Threading.Tasks;

namespace VendingMachine.DataServices.PaymentService
{
    public interface IPaymentService
    {
        Task<bool> IsCreditCardValid(string creditCardNo);
        Task<bool> HasEnoughCash(double price);
        Task<bool> ConfirmCreditCardPayment(double price);
        Task<bool> ConfirmCashPayment(double price);
    }
}
