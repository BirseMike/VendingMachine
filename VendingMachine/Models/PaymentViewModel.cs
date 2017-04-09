namespace VendingMachine.Models
{
    public class PaymentViewModel
    {
        public string CreditCardNo { get; set; }
        public double Cash { get; set; }
        public int ProductId { get; set; }
    }
}
