using AFI.Demo.Features.Customers.Models;
using MediatR;
using Customer = AFI.Demo.DataAccess.Customer;

namespace AFI.Demo.Features.Customers.Commands;

public class PostCustomerCommand : CustomerBase, IRequest<Customer> { }
