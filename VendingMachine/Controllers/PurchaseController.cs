using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VendingMachine.DataServices;
using VendingMachine.DataServices.PaymentService;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    public class PurchaseController : ApiController
    {
        private IPaymentService paymentService;
        private IProductRepository productRepository;

        public PurchaseController(IPaymentService paymentService, IProductRepository productRepository)
        {
            this.paymentService = paymentService;
            this.productRepository = productRepository;
        }

        // POST api/values
        public async Task<string> Post([FromBody] PaymentViewModel model)
        {
            //TODO:  Do something with 5% surcharge
            if (!string.IsNullOrEmpty(model.CreditCardNo))
            {
                bool isValidCard = await paymentService.IsCreditCardValid(model.CreditCardNo);
                if (!isValidCard)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent($"Invalid Credit Card Number : {model.CreditCardNo}"),
                        ReasonPhrase = "Invalid Credit Card Number"
                    };

                    throw new HttpResponseException(resp);
                }
            }
            var product = await productRepository.BuyProduct(model.ProductId);
            //TODO: Hook in payment service...
            return "Item Purchased";
        }
    }
}
