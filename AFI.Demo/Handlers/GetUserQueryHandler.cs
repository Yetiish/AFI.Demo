using AFI.Demo.DataAccess;
using AFI.Demo.Queries;
using AutoMapper;
using MediatR;

namespace AFI.Demo.Handlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User?>
{
    private readonly AppDbContext _dbContext;

    public GetUserQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);
    }
}
