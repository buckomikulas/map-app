using AutoMapper;
using map_app_api.Dto;
using map_app_api.Interfaces;
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

        [HttpGet("{stopId}/{routeId}")]
        [ProducesResponseType(200, Type = typeof(StopDTO))]
        public IActionResult GetStop(int stopId, int routeId)
        {
            var stop = m_mapper.Map<StopDTO>(m_stopRepository.GetStop(stopId, routeId));

            if(stop == null)
                return NotFound($"Stop with id {stopId}, on route with id {routeId} not found.");

            return Ok(stop);
        }
    }
}
