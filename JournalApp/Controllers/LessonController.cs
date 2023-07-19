using LogicLayer.Dto.lesson;
using LogicLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly LessonService service;

        public LessonController(LessonService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(service.Get());

        [HttpGet("{id}", Name = "LessonById")]
        public IActionResult Get(int id) => Ok(service.Get(id));

        [HttpPost]
        public IActionResult Add(LessonCreateDto dto)
        {
            var added = service.Add(dto);
            return CreatedAtRoute("LessonById", new { id = added.Id }, added);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
