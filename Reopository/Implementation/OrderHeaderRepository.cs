using AghaShad_Shop.DataContext;
using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class OrderHeaderRepository : BaseRepository<OrderHeader, int>, IOrderHeaderRepository
    {
        private readonly ShoppingContext _context;

        public OrderHeaderRepository(ShoppingContext context) : base(context) 
        {
            _context = context;
        }

        public async Task DeleteOrderHeader(int id) => await DeleteAndSaveAsync(id);

        public async Task<List<OrderHeader?>> GetCustomerAllOrderHeaders(int customerId)
        {
            return await _context.OrderHeaders
                        .Include(cus => cus.Customer)
                        .Where(order => order.CustomerId == customerId)
                        .ToListAsync();
        }
        
        public async Task<OrderHeader?> GetOrderHeaderById(int id)
        {
            return await _context.OrderHeaders.FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<int> InsertOrderHeader(RegisterOrderHeaderDto form)
        {
            OrderHeader order = new()
            {
                CustomerId = form.CustomerId,
                OrderDate = DateTime.UtcNow,
                ShippingId = form.ShipperId
            };

            await AddAndSaveAsync(order);
            return order.Id;    
        }

        public async Task UpdateOrderHeader(int id, RegisterOrderHeaderDto form)
        {
            OrderHeader? order = await _context.OrderHeaders.FirstOrDefaultAsync(order => order.Id == id);

            if (order == null) throw new Exception("Order not found");

            order.ShippingId = form.ShipperId;
            order.CustomerId = form.CustomerId;
        }
    }
}
