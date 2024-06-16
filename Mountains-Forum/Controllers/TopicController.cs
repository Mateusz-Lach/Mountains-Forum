using Microsoft.AspNetCore.Mvc;
using Mountains_Forum.Models;
using Mountains_Forum.Services;

namespace Mountains_Forum.Controllers
{
    [ApiController]
    [Route("mountains/category")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _service;
        public TopicController(ITopicService service) 
        {
            _service= service;
        }
        [HttpGet("{categoryId}")]
        public ActionResult GetAllById([FromRoute] int categoryId)
        {
            var result = _service.GetAllTopicsById(categoryId);

            return Ok(result);
        }
        [HttpPut]
        public ActionResult CreateById([FromRoute] int categoryId, [FromBody] CreateTopicDto dto)
        {
            var result = _service.CreateTopic(categoryId, dto);

            return Created("mountains/topic", null);
        }
    }
}
