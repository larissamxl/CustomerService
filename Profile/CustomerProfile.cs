using AutoMapper;
using CustomerService.Dtos;
using CustomerService.Model;

namespace CustomerService.Map
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerReadDto, CustomerPublishedDto>();
        }
    }
}
