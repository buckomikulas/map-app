using map_app_api.Interfaces;
using map_app_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace map_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // endpoint is api/users
    public class UserController : ControllerBase
    {

        private readonly IUserRepository m_userRepository;

        // Constructor injection 
        public UserController(IUserRepository userRepository)
        {
            m_userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = m_userRepository.GetUsers();

            if (users == null || !users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = m_userRepository.GetUser(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");
            return Ok(user);

        }
    }
}
