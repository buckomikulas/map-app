using AutoMapper;
using map_app_api.Dto;
using map_app_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace map_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRouteController : ControllerBase
    {
        private readonly IUserRouteRepository m_userRouteRepository;
        private readonly IMapper m_mapper;
        public UserRouteController(IUserRouteRepository userRouteRepository, IMapper mapper)
        {
            m_userRouteRepository = userRouteRepository;
            m_mapper = mapper;
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateUserRoute([FromBody] UserRouteCreateDTO userRoute)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userRouteModel = m_mapper.Map<Models.UserRoute>(userRoute);
            if (!m_userRouteRepository.CreateUserRoute(userRouteModel))
            {
                ModelState.AddModelError("", "Something went wrong while saving the user route.");
                return StatusCode(500, ModelState);
            }
            return Ok("User route created successfully.");
        }
    }
}
