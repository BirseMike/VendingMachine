using System;
using System.Threading.Tasks;

namespace VendingMachine.ExternalServices
{
    public class CreditCardService : ICreditCardService
    {
        //TODO:  Do something with 5% surcharge

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
