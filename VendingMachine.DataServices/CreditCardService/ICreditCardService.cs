namespace VendingMachine.DataServices.CreditCardService
{
    interface ICreditCardService
    {
        bool PaymentAccepted(string creditCardNumber);
    }
}