using AghaShad_Shop.DataContext;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.QueryService.Interface;
using AghaShad_Shop.Views;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.QueryService
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ShoppingContext _context;

        public CustomerQueryService(ShoppingContext context)
        {
            _context = context;
        }

        public async Task<CustomerAddressView?> GetCustomerAddress(int customerId)
        {
            CustomerAddressView? addressView = await _context.CustomerAddressView
                                               .FirstOrDefaultAsync(cus => cus.Id == customerId);
            if (addressView == null) throw new Exception("Customer not found");
            return addressView;
        }
    }
}
