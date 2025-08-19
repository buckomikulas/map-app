using AutoMapper;
using map_app_api.Dto;
using map_app_api.Interfaces;
using map_app_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace map_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StopController : ControllerBase
    {
        private readonly IStopRepository m_stopRepository;
        private readonly IMapper m_mapper;
        public StopController(IStopRepository stopRepository, IMapper mapper)
        {
            m_stopRepository = stopRepository;
            m_mapper = mapper;
        }
        //-------------------------------------------------------------------------------

        [HttpGet("{stopId}/{routeId}")]
        [ProducesResponseType(200, Type = typeof(StopDTO))]
        public IActionResult GetStop(int stopId, int routeId)
        {
            var stop = m_mapper.Map<StopDTO>(m_stopRepository.GetStop(stopId, routeId));

            if (stop == null)
                return NotFound($"Stop with id {stopId}, on route with id {routeId} not found.");

            return Ok(stop);
        }
        //-------------------------------------------------------------------------------

        [HttpGet("by-name/{stopName}/{routeName}")]
        [ProducesResponseType(200, Type = typeof(StopDTO))]
        public IActionResult GetStop(string stopName, string routeName)
        {
            var stop = m_mapper.Map<StopDTO>(m_stopRepository.GetStop(stopName, routeName));

            if (stop == null)
                return NotFound($"Stop called {stopName}, on route {routeName} not found.");

            return Ok(stop);
        }
        //-------------------------------------------------------------------------------

        [HttpDelete("{stopId}/{routeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        // Deletes a route WITH all its stops and the record in UserRoute table!!!
        // RouteTag table is not finished yet so the record wont be deleted BUT IT SHOULD AND WILL IN THE FUTURE
        public IActionResult DeleteRoute(int stopId, int routeId)
        {
            if (!m_stopRepository.StopExists(stopId, routeId))
            {
                return NotFound($"Stop with ID {stopId} on route with ID {routeId} not found.");
            }

            var toDel = m_stopRepository.GetStop(stopId, routeId);

            if (toDel == null)
            {
                return NotFound($"Stop with ID {stopId} on route with ID {routeId} not found.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!m_stopRepository.DeleteStopFromRoute(stopId, routeId))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the stop.");
                return StatusCode(500, ModelState);
            }

            return Ok($"Stop with ID {stopId} on route with ID {routeId} deleted successfully.");
        }


    }
}
