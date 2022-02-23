using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface ICustomerRepository
    {
        Task<int> InsertCustomer(RegisterCustomerDto form);
        Task UpdateCustomer(int id, RegisterCustomerDto form);
        Task DeleteCustomer(int id);
        Task<Customer?> GetCustomerById(int id);
        Task<Customer?> GetCustomerByFullName(string name);
        Task<List<Customer?>> GetAllCustomers();

    }
}
