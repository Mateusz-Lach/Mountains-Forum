using Microsoft.AspNetCore.Mvc;
using Mountains_Forum.Models;
using Mountains_Forum.Services;

namespace Mountains_Forum.Controllers
{
    [ApiController]
    [Route("mountains/category={categoryId}")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _service;
        public TopicController(ITopicService service) 
        {
            _service= service;
        }
        [HttpGet]
        public ActionResult GetAllById([FromRoute] int categoryId)
        {
            var result = _service.GetAllTopicsById(categoryId);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int categoryId,int id)
        {
            var result = _service.GetTopicById(categoryId, id);

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
