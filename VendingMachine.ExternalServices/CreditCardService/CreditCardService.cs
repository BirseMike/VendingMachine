namespace VendingMachine.ExternalServices
{
    class CreditCardService : ICreditCardService
    {
        public bool PaymentAccepted(string creditCardNumber)
        {
            return creditCardNumber.Length < 16;
        }
    }
}
