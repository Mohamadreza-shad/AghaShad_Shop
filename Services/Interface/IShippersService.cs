using AghaShad_Shop.Forms;
using AghaShad_Shop.OutPut;

namespace AghaShad_Shop.Services.Interface
{
    public interface IShippersService
    {
        Task RegisterShipper(RegisterShipperForm form);
        Task UpdateShipper(int shipperId, RegisterShipperForm form);
        Task DeleteShipper(int shipperId);
        Task<ApiResponseResult<ShipperOutput>> GetShipperById(int shipperId);
        Task<ApiResponseResult<List<ShipperOutput>>> GetAllShippers();
    }
}
