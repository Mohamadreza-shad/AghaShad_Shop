using AghaShad_Shop.DTOs;
using AghaShad_Shop.Forms;
using AghaShad_Shop.Models;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.Reopository.Interface;
using AghaShad_Shop.Services.Interface;

namespace AghaShad_Shop.Services.Implementation
{
    public class ShippersService : IShippersService
    {
        private readonly IShippingRepository _shippingRepository;

        public ShippersService(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        public async Task DeleteShipper(int shipperId)
        {
            await _shippingRepository.DeleteShipping(shipperId);
        }

        public async Task<List<ShipperOutput>> GetAllShippers()
        {
            List<Shipping> shippersList =  await _shippingRepository.GetAllShippings();
            List<ShipperOutput> shipperOutputs = new();

            foreach (Shipping shipper in shippersList)
            {
                shipperOutputs.Add(new ShipperOutput { Name = shipper.Name });
            }
            return shipperOutputs;

        }

        public async Task<ShipperOutput> GetShipperById(int shipperId)
        {
            Shipping shipping = await _shippingRepository.GetShippingById(shipperId);
            return new ShipperOutput { Name = shipping.Name };
        }

        public async Task RegisterShipper(RegisterShipperForm form)
        {
            RegisterShippingDto shippingDto = new(){Name = form.Name};

            await _shippingRepository.InsertShipping(shippingDto);
        }

        public async Task UpdateShipper(int shipperId, RegisterShipperForm form)
        {
            RegisterShippingDto shippingDto = new() { Name = form.Name };
            await _shippingRepository.UpdateShipping(shipperId, shippingDto);
        }
    }
}
