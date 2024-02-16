using AFI.Demo.DataAccess;
using AFI.Demo.Features.Customers.Queries;
using MediatR;

namespace AFI.Demo.Features.Customers.Handlers;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer?>
{
    private readonly AppDbContext _dbContext;

    public GetCustomerQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Customers.SingleOrDefault(u => u.Id == request.Id);
    }
}
