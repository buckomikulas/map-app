using map_app_api.Interfaces;
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
        public IActionResult GetUsers()
        {
            var users = m_userRepository.GetUsers();

            if(users == null || !users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }

    }
}
