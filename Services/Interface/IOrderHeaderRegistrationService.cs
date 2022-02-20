using AghaShad_Shop.Forms;

namespace AghaShad_Shop.Services.Interface
{
    public interface IOrderHeaderRegistrationService
    {
        Task RegisterOrderHeader(RegisterOrderForm form);
    }
}
