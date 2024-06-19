using Microsoft.AspNetCore.Mvc;
using Mountains_Forum.Models;
using Mountains_Forum.Services;

namespace Mountains_Forum.Controllers
{
    [ApiController]
    [Route("mountains")]
    public class MainController : ControllerBase
    {
        private readonly IMainService _service;
        public MainController(IMainService service)
        {
            _service= service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _service.GetAllCategories();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id) 
        {
            var result = _service.GetCategoryById(id);

            return Ok(result);
        }

        [HttpPut]
        public ActionResult CreateCategory([FromBody] CreateCategoryDto dto)
        {
            var createdId = _service.CreateCategory(dto);

            return Created($"/mountains/{createdId}", null);
        }
    }
}
