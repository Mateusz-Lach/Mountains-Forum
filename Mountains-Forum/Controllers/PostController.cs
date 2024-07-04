using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Mountains_Forum.Models;
using Mountains_Forum.Services;

namespace Mountains_Forum.Controllers
{
    [ApiController]
    [Route("mountains/category={categoryId}/topic={topicId}")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService _postService)
        {
            postService = _postService;
        }
        [HttpGet]
        public ActionResult GetAllPostsByTopicId([FromRoute] int categoryId, [FromRoute] int topicId)
        {
            var result = postService.GetAlGetAllPosts(categoryId, topicId);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetPostById([FromRoute] int categoryId, [FromRoute] int topicId, [FromRoute] int id)
        {
            var result = postService.GetPostById(categoryId, topicId, id);

            return Ok(result);
        }
        [HttpPut]
        public ActionResult CreatePost([FromRoute] int categoryId, [FromRoute] int topicId, [FromBody] CreatePostDto dto)
        {
            var result = postService.CreatePost(categoryId, topicId, dto);

            return Created("mountains/category={categoryId}/topic", null);
        }
        [HttpDelete]
        public ActionResult DeletePost([FromRoute] int categoryId, [FromRoute] int topicId, [FromRoute] int id)
        {
            var isDeleted = postService.DeletePost(categoryId, topicId, id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
