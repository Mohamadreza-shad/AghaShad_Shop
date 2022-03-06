using AghaShad_Shop.Forms;
using AghaShad_Shop.OutPut;

namespace AghaShad_Shop.Services.Interface
{
    public interface ICustomerRegisterationService
    {
        Task<int> RegiterCustomer(CustomerRegisterationForm form);
        Task UpdateCustomer(int customerId, CustomerRegisterationForm form);
        Task<ApiResponseResult<CustomerOutPut>> GetCustomerByIdAsync(int customerId);
    }
}
