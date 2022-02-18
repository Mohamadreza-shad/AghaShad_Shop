using AghaShad_Shop.Forms;

namespace AghaShad_Shop.Services.Interface
{
    public interface ICustomerRegisteration
    {
        Task RegiterCustomer(CustomerRegisterationForm form);
    }
}
