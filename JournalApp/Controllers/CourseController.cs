using LogicLayer.Dto.course;
using LogicLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService service;

        public CourseController(CourseService courseService)
        {
            this.service = courseService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(service.Get());

        [HttpGet("{id}", Name = "CourseById")]
        public IActionResult GetCourse(int id) => Ok(service.Get(id));

        [HttpPost]
        public IActionResult Add(CourseCreateByProfile dto)
        {
            if (ModelState.IsValid)
            {
                var added = service.Add(dto);


                return CreatedAtRoute("CourseById", new { id = added.Id }, added);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseCreateDto dto)
        {
            service.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
