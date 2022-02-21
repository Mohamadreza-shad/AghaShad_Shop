using AghaShad_Shop.Forms;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AghaShad_Shop.Controllers
{
    public class ShippingController : BaseApiController
    {
        private readonly IShippersService _shippersService;

        public ShippingController(IShippersService shippersService)
        {
            _shippersService = shippersService;
        }

        [HttpPost("InsertShippers")]
        public async Task InsertShippers(RegisterShipperForm form)
        {
            await _shippersService.RegisterShipper(form);
        }

        [HttpPut("UpdateShippers")]
        public async Task UpdateShippers(int shipperId,RegisterShipperForm form)
        {
            await _shippersService.UpdateShipper(shipperId, form);
        }

        [HttpDelete("DeleteShippers")]
        public async Task DeleteShippers(int shipperId)
        {
            await _shippersService.DeleteShipper(shipperId);
        }

        [HttpGet("GetShipperById")]
        public async Task<ShipperOutput> GetShipperById(int shipperId)
        {
            return await _shippersService.GetShipperById(shipperId);    
        }

        [HttpGet("GetShippers")]
        public async Task<List<ShipperOutput>> GetShippers()
        {
            return await _shippersService.GetAllShippers();
        }


    }
}
