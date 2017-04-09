using System;
using System.Threading.Tasks;
using VendingMachine.DataServices.CashRepositories;
using VendingMachine.ExternalServices;

namespace VendingMachine.DataServices.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private ICreditCardService creditCardService;
        private ICustomerCashRepository customerCashRepository;
        private IMachineCashRepository machineCashRepository;

        private string creditCardNo = "";

        public PaymentService(ICreditCardService creditCardService, ICustomerCashRepository customerCashRepository, IMachineCashRepository machineCashRepository)
        {
            this.creditCardService = creditCardService;
            this.customerCashRepository = customerCashRepository;
            this.machineCashRepository = machineCashRepository;

        }
        public async Task<bool> IsCreditCardValid(string creditCardNo)
        {
            this.creditCardNo = creditCardNo;
            return await creditCardService.IsCardValid(creditCardNo);
        }

        public async Task<bool> HasEnoughCash(double price)
        {
            double balance = await customerCashRepository.GetCurrentBalance();
            return balance >= price;
        }

        public async Task<bool> ConfirmCreditCardPayment(double price)
        {
            return await creditCardService.PaymentAccepted(creditCardNo);
        }

        public Task<bool> ConfirmCashPayment(double price)
        {
            throw new NotImplementedException();
        }
    }
}
