using AutoMapper;
using map_app_api.Dto;
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
        private readonly IMapper m_mapper;

        // Constructor injection 
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            m_userRepository = userRepository;
            m_mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetUsers()
        {

            // Using AutoMapper to map User to UserDTO
            var users = m_mapper.Map<IEnumerable<UserDTO>>(m_userRepository.GetUsers());

            if (users == null || !users.Any())
                return NotFound("No users found.");

            return Ok(users);
        }
        //-------------------------------------------------------------------------------

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetUser(int userId)
        {
            var user = m_mapper.Map<UserDTO>(m_userRepository.GetUser(userId));

            if (user == null)
                return NotFound($"User with ID {userId} not found.");
            return Ok(user);

        }
        //-------------------------------------------------------------------------------

        [HttpGet("name/{userName}")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetUserByName(string userName)
        {
            var user = m_mapper.Map<UserDTO>(m_userRepository.GetUser(userName));

            if (user == null)
                return NotFound($"User with name {userName} not found.");

            return Ok(user);
        }
        //-------------------------------------------------------------------------------

        [HttpGet("routes/{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RouteDTO>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetRoutesByUserId(int userId)
        {
            var routes = m_mapper.Map<IEnumerable<RouteDTO>>(m_userRepository.GetUserRoutes(userId));

            if (routes == null || !routes.Any())
                return NotFound($"No routes found for user with ID {userId}.");

            return Ok(routes);
        }
    }
}
