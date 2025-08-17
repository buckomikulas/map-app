using AutoMapper;
using map_app_api.Dto;
using map_app_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace map_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class TagController : ControllerBase
    {
        private readonly ITagRepository m_tagRepository;
        private readonly IMapper m_mapper;


        public TagController(ITagRepository tagRepository, IMapper mapper)
        {
            m_tagRepository = tagRepository;
            m_mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TagDTO>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public IActionResult GetTags()
        {
            var tags = m_mapper.Map<IEnumerable<TagDTO>>(m_tagRepository.GetTags());
            
            if (tags == null || !tags.Any())
                return NotFound("No tags found.");

            return Ok(tags);
        }

    }
}
