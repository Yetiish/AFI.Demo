using AFI.Demo.DataAccess;
using MediatR;

namespace AFI.Demo.Features.Customers.Queries;

public class GetCustomerQuery : IRequest<Customer?>
{
    public int Id { get; set; }
}
