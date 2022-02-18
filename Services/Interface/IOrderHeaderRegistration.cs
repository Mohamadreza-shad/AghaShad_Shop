using AghaShad_Shop.Forms;

namespace AghaShad_Shop.Services.Interface
{
    public interface IOrderHeaderRegistration
    {
        Task RegisterOrderHeader(RegisterOrderForm form);
    }
}
