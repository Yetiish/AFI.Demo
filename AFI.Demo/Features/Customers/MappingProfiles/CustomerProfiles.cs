using AFI.Demo.Features.Customers.Commands;
using AFI.Demo.Features.Customers.ViewModels;
using AutoMapper;
using Customer = AFI.Demo.DataAccess.Customer;

namespace AFI.Demo.Features.Customers.MappingProfiles;

public class CustomerProfiles : Profile
{
    public CustomerProfiles()
    {
        CreateMap<CustomerPostInput, PostCustomerCommand>();
        CreateMap<PostCustomerCommand, Customer>();
        CreateMap<Customer, ViewModels.Customer>();
    }
}
