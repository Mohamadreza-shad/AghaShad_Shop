using AghaShad_Shop.Forms;

namespace AghaShad_Shop.Services.Interface
{
    public interface ICustomerRegisterationService
    {
        Task RegiterCustomer(CustomerRegisterationForm form);
        Task UpdateCustomer(int customerId, CustomerRegisterationForm form);
    }
}
