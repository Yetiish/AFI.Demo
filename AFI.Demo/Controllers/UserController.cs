using AFI.Demo.Commands;
using AFI.Demo.Queries;
using AFI.Demo.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFI.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a users details
        /// </summary>
        /// <param name="id">The Id of the user to get details for</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The user</returns>
        [HttpGet(Name = "User")]
        public async Task<User> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery { Id = id };
            var user = await _mediator.Send(query, cancellationToken);

            var viewModel = _mapper.Map<User>(user);
            return viewModel;
        }

        /// <summary>
        /// The user to register
        /// </summary>
        /// <param name="input">The details to register for the user</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The registered user</returns>
        [HttpPut(Name = "User")]
        public async Task<User> Put(
            [FromBody] UserPutInput input,
            CancellationToken cancellationToken
        )
        {
            var command = new PutUserCommand { Input = input };
            var user = await _mediator.Send(command, cancellationToken);

            var viewModel = _mapper.Map<User>(user);
            return viewModel;
        }
    }
}
