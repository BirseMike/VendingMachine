using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VendingMachine.DataServices;
using VendingMachine.DataServices.CashRepositories;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    public class CustomerCashController : ApiController
    {
        private ICustomerCashRepository customerCashRepository;

        public CustomerCashController(ICustomerCashRepository customerCashRepository)
        {
            this.customerCashRepository = customerCashRepository;
        }
        // POST: api/CustomerCash
        public async Task<double> Post([FromBody] CustomerCashViewModel denom)
        {
            Demonination cashDenom;
            if (!Enum.TryParse(denom.Value.ToString(), out cashDenom))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Invalid Denomination : {denom.Value}"),
                    ReasonPhrase = "Cash Denomination Not Supported"
                };

                throw new HttpResponseException(resp);
            }

            return await customerCashRepository.Add(cashDenom);
        }
    }

}
