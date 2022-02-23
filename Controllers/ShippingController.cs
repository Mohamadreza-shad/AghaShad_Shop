using AghaShad_Shop.Errors;
using AghaShad_Shop.Forms;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> GetShipperById(int shipperId)
        {
            ApiResponseResult<ShipperOutput> apiResponseResult =
                                                    await _shippersService.GetShipperById(shipperId);

            return (apiResponseResult.HttpStatusCode == HttpStatusCode.OK) ?
                    Ok(apiResponseResult) :
                    NotFound(apiResponseResult);
        }

        [HttpGet("GetShippers")]
        public async Task<IActionResult> GetShippers()
        {
            ApiResponseResult<List<ShipperOutput>> apiResponseResult = await _shippersService.GetAllShippers();

            return (apiResponseResult.HttpStatusCode == HttpStatusCode.OK) ?
                    Ok(apiResponseResult) :
                    NotFound(apiResponseResult);
        }


    }
}
