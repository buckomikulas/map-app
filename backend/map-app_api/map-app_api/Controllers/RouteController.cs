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

        //-------------------------------------------------------------------------------

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RouteDTO>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetRoutes()
        {
            // Using AutoMapper to map User to UserDTO
            var routes = m_mapper.Map<IEnumerable<RouteDTO>>(m_routeRepository.GetRoutes());

            if (routes == null || !routes.Any())
                return NotFound("No users found.");

            return Ok(routes);
        }
        //-------------------------------------------------------------------------------

        [HttpGet("{routeId}")]
        [ProducesResponseType(200, Type = typeof(RouteDTO))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetRoute(int routeId)
        {
            var route = m_mapper.Map<RouteDTO>(m_routeRepository.GetRoute(routeId));

            if (route == null)
                return NotFound($"Route with ID {routeId} not found.");

            return Ok(route);
        }
        //-------------------------------------------------------------------------------

        [HttpGet("name/{routeName}")]
        [ProducesResponseType(200, Type = typeof(RouteDTO))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetRouteByName(string routeName)
        {
            var route = m_mapper.Map<RouteDTO>(m_routeRepository.GetRoute(routeName));

            if (route == null)
                return NotFound($"Route with name {routeName} not found.");

            return Ok(route);
        }
        //-------------------------------------------------------------------------------

        [HttpGet("stops/{routeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StopDTO>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetStopsByRouteId(int routeId)
        {
            var stops = m_mapper.Map<IEnumerable<StopDTO>>(m_routeRepository.GetStopsOnRoute(routeId));
            if (stops == null || !stops.Any())
                return NotFound($"No stops found for route ID {routeId}.");
            
            return Ok(stops);
        }
        //-------------------------------------------------------------------------------

        [HttpPatch("add-stops")]
        public IActionResult AddStops([FromBody] AddStopsDTO dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var stops = m_mapper.Map<List<Stop>>(dto.Stops);

            if(!m_routeRepository.AddStopToRoute(dto.RouteId, stops))
            {
                ModelState.AddModelError("", "Something went wrong while adding stops to the route.");
                return StatusCode(500, ModelState);
            }

            return Ok("Stops added successfully to the route.");
        }
        //-------------------------------------------------------------------------------

        [HttpDelete("{routeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        // Deletes a route WITH all its stops and the record in UserRoute table!!!
        // RouteTag table is not finished yet so the record wont be deleted BUT IT SHOULD AND WILL IN THE FUTURE
        public IActionResult DeleteRoute(int routeId)
        {
            if(!m_routeRepository.RouteExists(routeId))
            {
                return NotFound($"Route with ID {routeId} not found.");
            }

            var toDel = m_routeRepository.GetRoute(routeId);

            if (toDel == null)
            {
                return NotFound("Route not found.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!m_routeRepository.DeleteRoute(toDel))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the route.");
                return StatusCode(500, ModelState);
            }

            return Ok($"Route with ID {routeId} deleted successfully.");

        }

    }
}
