using AghaShad_Shop.Forms;
using AghaShad_Shop.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AghaShad_Shop.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerRegisterationService _customerRegisteration;

        public CustomerController(ICustomerRegisterationService customerRegisteration)
        {
            _customerRegisteration = customerRegisteration;
        }

        [HttpPost("RegisterCustomer")]
        public async Task RegisterCustomerAsync(CustomerRegisterationForm form)
        {
            await _customerRegisteration.RegiterCustomer(form);
        }

        [HttpPut("UpdateCustomer")]
        public async Task UpdateCustomerAsync(int customerId, CustomerRegisterationForm form)
        {
            await _customerRegisteration.UpdateCustomer(customerId,form);
        }

    }
}
