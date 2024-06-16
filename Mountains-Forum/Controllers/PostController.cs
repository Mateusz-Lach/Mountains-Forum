using Microsoft.AspNetCore.Mvc;
using Mountains_Forum.Models;
using Mountains_Forum.Services;

namespace Mountains_Forum.Controllers
{
    [ApiController]
    [Route("mountains/post")]
    public class PostController : ControllerBase
    {
        public PostController()
        {

        }
        [HttpGet("{topicId}")]
        public ActionResult GetAllPostsByTopicId([FromRoute] int topicId)
        {
            return Ok(topicId);
        }
    }
}
