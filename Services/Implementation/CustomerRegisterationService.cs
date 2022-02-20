using AghaShad_Shop.DTOs;
using AghaShad_Shop.Forms;
using AghaShad_Shop.Models;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.Reopository.Interface;
using AghaShad_Shop.Services.Interface;

namespace AghaShad_Shop.Services.Implementation
{
    public class CustomerRegisterationService : ICustomerRegisterationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        public CustomerRegisterationService(ICustomerRepository customerRepository,
                                     IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public async Task<CustomerOutPut> GetCustomerByIdAsync(int customerId)
        {

            // Create a view and read instead of this shit.
            Customer customer = await _customerRepository.GetCustomerById(customerId);

            Address address = await _addressRepository.GetAddressById(customerId);

            return new CustomerOutPut
            {
                CustomerId = customer.Id,
                Phone = customer.Phone,
                FullName = customer.FullName,
                City = address.City,
                Description = address.Description,
                Province = address.Province,
            };
        }

        public async Task RegiterCustomer(CustomerRegisterationForm form)
        {
            RegisterCustomerDto registerCustomerDto = new()
            {
                FullName = form.FullName,
                Phone = form.Phone,
            };

            int customerId = await _customerRepository.InsertCustomer(registerCustomerDto);

            RegisterAddressDto addressDto = new()
            {
                City = form.City,
                CustomerId = customerId,
                Description = form.Description,
                Province = form.Province
            };

            await _addressRepository.InsertAddress(addressDto);
        }

        public async Task UpdateCustomer(int customerId, CustomerRegisterationForm form)
        {
            RegisterCustomerDto customerDto = new()
            {
                FullName = form.FullName, 
                Phone = form.Phone,
            };
            await _customerRepository.UpdateCustomer(customerId, customerDto);

            RegisterAddressDto addressDto = new()
            {
                City = form.City,
                Description = form.Description,
                Province = form.Province
            };

            await _addressRepository.UpdateAddress(customerId, addressDto);
        }
    }
}
