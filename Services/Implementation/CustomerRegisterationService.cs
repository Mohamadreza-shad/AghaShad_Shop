using AghaShad_Shop.DTOs;
using AghaShad_Shop.Errors;
using AghaShad_Shop.Forms;
using AghaShad_Shop.Models;
using AghaShad_Shop.OutPut;
using AghaShad_Shop.QueryService.Interface;
using AghaShad_Shop.Reopository.Interface;
using AghaShad_Shop.Services.Interface;
using AghaShad_Shop.Views;
using System.Net;

namespace AghaShad_Shop.Services.Implementation
{
    public class CustomerRegisterationService : ICustomerRegisterationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerQueryService _customerQueryService;

        public CustomerRegisterationService(ICustomerRepository customerRepository,
                                            IAddressRepository addressRepository,
                                            ICustomerQueryService customerQueryService)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _customerQueryService = customerQueryService;
        }

        public async Task<ApiResponseResult<CustomerOutPut?>> GetCustomerByIdAsync(int customerId)
        {
            CustomerAddressView? customerOutPut = await _customerQueryService.GetCustomerAddress(customerId);
            if (customerOutPut == null)
            {
                return new ApiResponseResult<CustomerOutPut?>
                {
                    Error = Error.CustomerNotFound,
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            return new ApiResponseResult<CustomerOutPut>
            {
                Result = new CustomerOutPut
                {
                    City = customerOutPut.City,
                    CustomerId = customerOutPut.Id,
                    Description = customerOutPut.Description,
                    FullName = customerOutPut.FullName,
                    Phone = customerOutPut.Phone,
                    Province = customerOutPut.Province
                },
                HttpStatusCode = HttpStatusCode.OK
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
