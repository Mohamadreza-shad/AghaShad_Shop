using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface IOrderHeaderRepository
    {
        Task<int> InsertOrderHeader(RegisterOrderHeaderDto form);
        Task UpdateOrderHeader(int id, RegisterOrderHeaderDto form);
        Task DeleteOrderHeader(int id);
        Task<OrderHeader> GetOrderHeaderById(int id);
        Task<List<OrderHeader>> GetCustomerAllOrderHeaders(int customerid);
    }
}
