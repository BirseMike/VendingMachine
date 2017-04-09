namespace VendingMachine.ExternalServices
{
    interface ICreditCardService
    {
        bool PaymentAccepted(string creditCardNumber);
    }
}