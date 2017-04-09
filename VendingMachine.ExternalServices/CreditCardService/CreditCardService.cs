using System;
using System.Threading.Tasks;

namespace VendingMachine.ExternalServices
{
    public class CreditCardService : ICreditCardService
    {
        public async Task<bool> IsCardValid(string creditCardNumber)
        {
            return await Task.Run(() => creditCardNumber.Length == 16);
        }

        public async Task<bool> PaymentAccepted(string creditCardNumber)
        {
            bool valid = await IsCardValid(creditCardNumber);
            return valid;
        }
    }
}
