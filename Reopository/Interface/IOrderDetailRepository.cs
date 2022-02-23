using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface IOrderDetailRepository
    {
        Task<int> InsertOrderDetail(RegisterOrderDetailDto form);
        Task UpdateOrderDetail(int id, RegisterOrderDetailDto form);
        Task DeleteOrderDetail(int id);
        Task<OrderDetail?> GetOrderDetailById(int id);
        Task<List<OrderDetail?>> GetOrderHeaderAllOrderDetails(int Orderid);
    }
}
