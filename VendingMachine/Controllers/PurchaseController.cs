using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VendingMachine.DataServices.PaymentService;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    public class PurchaseController : ApiController
    {
        private IPaymentService paymentService;

        public PurchaseController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        // POST api/values
        public async Task<string> Post([FromBody] PaymentViewModel model)
        {
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
            //var product = await productRepository.BuyProduct(model.ProductId);
            return "Item Purchased";
        }
    }
}
