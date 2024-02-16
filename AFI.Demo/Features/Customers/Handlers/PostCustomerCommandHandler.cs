using AFI.Demo.DataAccess;
using AFI.Demo.Features.Customers.Commands;
using AutoMapper;
using MediatR;

namespace AFI.Demo.Features.Customers.Handlers;

public class PostCustomerCommandHandler : IRequestHandler<PostCustomerCommand, Customer>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public PostCustomerCommandHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Customer> Handle(PostCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(command);

        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return customer;
    }
}
