using AghaShad_Shop.Views;

namespace AghaShad_Shop.QueryService.Interface
{
    public interface ICustomerQueryService
    {
        Task<CustomerAddressView?> GetCustomerAddress(int customerId);
    }
}
