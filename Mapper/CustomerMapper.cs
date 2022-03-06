using AghaShad_Shop.DTOs;
using AghaShad_Shop.Forms;
using AghaShad_Shop.Models;
using AutoMapper;

namespace AghaShad_Shop.Mapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerRegisterationForm, RegisterCustomerDto>();
            CreateMap<CustomerRegisterationForm, RegisterAddressDto>();
            CreateMap<RegisterCustomerDto, Customer>();

        }
    }
}
