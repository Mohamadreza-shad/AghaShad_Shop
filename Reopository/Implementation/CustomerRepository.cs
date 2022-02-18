using AghaShad_Shop.DataContext;
using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class CustomerRepository : BaseRepository<Customer,int>, ICustomerRepository
    {
        private readonly ShoppingContext _context;

        public CustomerRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteCustomer(int id) => await DeleteAndSaveAsync(id);

        public async Task<List<Customer>> GetAllCustomers() => await _context.Customers.ToListAsync();
        
        public async Task<Customer> GetCustomerByFullName(string name)
        {
            Customer? customer = await _context.Customers
                                 .FirstOrDefaultAsync(customer => customer.FullName == name);

            if (customer == null) throw new Exception("Customer not Found");
            return customer;    
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Customer? customer = await FindAsync(id);
            if (customer == null) throw new Exception("Customer not Found");
            return customer;
        }

        public async Task<int> InsertCustomer(RegisterCustomerDto form)
        {
            Customer customer = new()
            {
                FullName = form.FullName,
                Phone = form.Phone
            };

            await AddAndSaveAsync(customer); 
            return customer.Id;
        }

        public async Task UpdateCustomer(int id, RegisterCustomerDto form)
        {
            Customer? customer = await FindAsync(id);
            if (customer == null) throw new Exception("Customer not Found");

            customer.Phone = form.Phone;
            customer.FullName = form.FullName;

            await UpdateAndSaveAsync(customer);
        }
    }
}
