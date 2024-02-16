using AFI.Demo.Features.Customers.Commands;
using AFI.Demo.Features.Customers.Queries;
using AFI.Demo.Features.Customers.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AFI.Demo.Features.Customers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a customers details
        /// </summary>
        /// <param name="id">The Id of the customer to get details for</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The customer</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<Customer> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetCustomerQuery { Id = id };
            var customer = await _mediator.Send(query, cancellationToken);

            var viewModel = _mapper.Map<Customer>(customer);
            return viewModel;
        }

        /// <summary>
        /// The customer to register
        /// </summary>
        /// <param name="input">The details to register for the customer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The registered customer</returns>
        [HttpPost(Name = "Customer")]
        public async Task<Customer> Post(
            [FromBody] CustomerPostInput input,
            CancellationToken cancellationToken
        )
        {
            var command = _mapper.Map<PostCustomerCommand>(input);
            var customer = await _mediator.Send(command, cancellationToken);

            var viewModel = _mapper.Map<Customer>(customer);
            return viewModel;
        }
    }
}
