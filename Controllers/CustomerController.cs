using AghaShad_Shop.Forms;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AghaShad_Shop.Controllers
{
    [Route("api/customers")]

    public class CustomerController : BaseApiController
    {
        private readonly ICustomerRegisterationService _customerRegisteration;

        public CustomerController(ICustomerRegisterationService customerRegisteration)
        {
            _customerRegisteration = customerRegisteration;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterCustomerAsync(CustomerRegisterationForm form)
        {
            int customerId = await _customerRegisteration.RegiterCustomer(form);
            return Created(nameof(GetCustomerByIdAsync), customerId);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomerAsync(int customerId, CustomerRegisterationForm form)
        {
            await _customerRegisteration.UpdateCustomer(customerId,form);
            return NoContent();
        }

        [HttpGet("{customerId}", Name = nameof(GetCustomerByIdAsync))]
        public async Task<ActionResult<ApiResponseResult<CustomerOutPut>>> GetCustomerByIdAsync(int customerId)
        {
            ApiResponseResult<CustomerOutPut> apiResponseResult = await _customerRegisteration.GetCustomerByIdAsync(customerId);

            return (apiResponseResult == null) ?
                NotFound(apiResponseResult) :
                Ok(apiResponseResult);
        }


    }
}
