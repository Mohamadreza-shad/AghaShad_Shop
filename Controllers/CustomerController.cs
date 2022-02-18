using AghaShad_Shop.Forms;
using AghaShad_Shop.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AghaShad_Shop.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerRegisteration _customerRegisteration;

        public CustomerController(ICustomerRegisteration customerRegisteration)
        {
            _customerRegisteration = customerRegisteration;
        }

        [HttpPost("RegisterCustomer")]
        public async Task RegisterCustomerAsync(CustomerRegisterationForm form)
        {
            await _customerRegisteration.RegiterCustomer(form);
        }


    }
}
