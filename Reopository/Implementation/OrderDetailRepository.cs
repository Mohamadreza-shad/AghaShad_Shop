using AghaShad_Shop.DataContext;
using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class OrderDetailRepository : BaseRepository<OrderDetail, int>, IOrderDetailRepository
    {
        private readonly ShoppingContext _context;
        private readonly IProductRepository _productRepository;

        public OrderDetailRepository(ShoppingContext context,
                                    IProductRepository productRepository) : base(context)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task DeleteOrderDetail(int id) => await DeleteAndSaveAsync(id);


        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            OrderDetail? orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (orderDetail == null) throw new Exception("Order Detail not found");

            return orderDetail;
        }

        public async Task<List<OrderDetail>> GetOrderHeaderAllOrderDetails(int orderid)
        {
            List<OrderDetail> orderDetails = await _context.OrderDetails
                                                    .Include(order => order.OrderHeader)
                                                    .Where(order => order.OrderHeaderId == orderid)
                                                    .ToListAsync();
            return orderDetails;
        }

        public async Task<int> InsertOrderDetail(RegisterOrderDetailDto form)
        {
            OrderDetail orderDetail = new()
            {
                OrderHeaderId = form.OrderId,
                ProductId = form.ProductId,
                Quantity = form.Quantity,
                UnitPrice = form.UnitPrice,
                TotalPrice = form.Quantity * form.UnitPrice
            };

            await AddAndSaveAsync(orderDetail);
            return orderDetail.Id;
        }

        public async Task UpdateOrderDetail(int id, RegisterOrderDetailDto form)
        {
            OrderDetail? orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (orderDetail == null) throw new Exception("Order Detail not found");

            orderDetail.Quantity = form.Quantity;
            orderDetail.ProductId = form.ProductId;
            orderDetail.OrderHeaderId = form.OrderId;

            await UpdateAndSaveAsync(orderDetail);  
        }
    }
}
