using AFI.Demo.ViewModels;
using MediatR;
using User = AFI.Demo.DataAccess.User;

namespace AFI.Demo.Commands;

public class PutUserCommand : IRequest<User>
{
    public UserPutInput Input { get; set; }
}
