using AghaShad_Shop.Errors;
using AghaShad_Shop.Forms;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetCustomerByIdAsync(int customerId)
        {
            ApiResponseResult<CustomerOutPut> apiResponseResult = await _customerRegisteration.GetCustomerByIdAsync(customerId);

            return (apiResponseResult == null) ?
                NotFound(apiResponseResult) :
                Ok(apiResponseResult);
        }


    }
}
