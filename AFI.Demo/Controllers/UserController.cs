using AFI.Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AFI.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a users details
        /// </summary>
        /// <param name="id">The Id of the user to get details for</param>
        /// <returns>The user</returns>
        [HttpGet(Name = "User")]
        public IEnumerable<User> Get(int id)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// The user to register
        /// </summary>
        /// <param name="input">The details to register for the user</param>
        /// <returns>The registered user</returns>
        [HttpPut(Name = "User")]
        public IEnumerable<User> Put([FromBody] UserPutInput input)
        {
            throw new NotImplementedException();
        }
    }
}
