using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface ICustomerRepository
    {
        Task InsertCustomer(RegisterCustomerForm form);
        Task UpdateCustomer(int id, RegisterCustomerForm form);
        Task DeleteCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task<Customer> GetCustomerByFullName(string name);
        Task<List<Customer>> GetAllCustomers();

    }
}
