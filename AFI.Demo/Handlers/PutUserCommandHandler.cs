using AFI.Demo.Commands;
using AFI.Demo.DataAccess;
using AutoMapper;
using MediatR;

namespace AFI.Demo.Handlers;

public class PutUserCommandHandler : IRequestHandler<PutUserCommand, User>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public PutUserCommandHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<User> Handle(PutUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.Input);

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }
}
