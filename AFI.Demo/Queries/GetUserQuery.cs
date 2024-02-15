using AFI.Demo.DataAccess;
using MediatR;

namespace AFI.Demo.Queries;

public class GetUserQuery : IRequest<User?>
{
    public int Id { get; set; }
}
