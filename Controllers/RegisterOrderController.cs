using AghaShad_Shop.Forms;
using AghaShad_Shop.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AghaShad_Shop.Controllers
{
    public class RegisterOrderController : BaseApiController
    {
        private readonly IOrderHeaderRegistrationService _orderRegistrationService;

        public RegisterOrderController(IOrderHeaderRegistrationService orderRegistrationService)
        {
            _orderRegistrationService = orderRegistrationService;
        }

        [HttpPost("RegisterOrder")]
        public async Task RegisterOrderAsync(RegisterOrderForm form)
        {
            await _orderRegistrationService.RegisterOrderHeader(form);
        }
    }
}
