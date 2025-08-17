using AutoMapper;
using map_app_api.Dto;
using map_app_api.Interfaces;
using map_app_api.Models;
using map_app_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace map_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // endpoint is api/routes
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository m_routeRepository;
        private readonly IMapper m_mapper;

        public RouteController(IRouteRepository routeRepository, IMapper mapper)
        {
            m_routeRepository = routeRepository;
            m_mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetRoutes()
        {
            // Using AutoMapper to map User to UserDTO
            var routes = m_mapper.Map<IEnumerable<RouteDTO>>(m_routeRepository.GetRoutes());

            if (routes == null || !routes.Any())
                return NotFound("No users found.");

            return Ok(routes);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoute(int id)
        {
            var route = m_mapper.Map<RouteDTO>(m_routeRepository.GetRoute(id));

            if (route == null)
                return NotFound($"Route with ID {id} not found.");

            return Ok(route);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetRouteByName(string name)
        {
            var route = m_mapper.Map<RouteDTO>(m_routeRepository.GetRoute(name));

            if (route == null)
                return NotFound($"Route with name {name} not found.");

            return Ok(route);
        }

        [HttpGet("stops/{routeId}")]
        public IActionResult GetStopsByRouteId(int routeId)
        {
            var stops = m_mapper.Map<IEnumerable<StopDTO>>(m_routeRepository.GetStopsOnRoute(routeId));
            if (stops == null || !stops.Any())
                return NotFound($"No stops found for route ID {routeId}.");
            
            return Ok(stops);
        }
    }
}
