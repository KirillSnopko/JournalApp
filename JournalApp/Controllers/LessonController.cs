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

        [HttpGet("{id}/topics")]
        public IActionResult GetTopics(int id) => Ok(service.getAccessibleTopicsByLessonId(id));

        [HttpGet("stat")]
        public IActionResult GetStat() => Ok(service.Stat());

        [HttpPost]
        public IActionResult Add(LessonCreateDto dto)
        {
            var added = service.Add(dto);
            return CreatedAtRoute("LessonById", new { id = added.Id }, added);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, LessonUpdateDto dto)
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
