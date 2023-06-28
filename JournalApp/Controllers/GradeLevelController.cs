using LogicLayer.Dto.gradeLevel;
using LogicLayer.Dto.topic;
using LogicLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeLevelController : ControllerBase
    {
        private readonly GradeLevelService service;

        public GradeLevelController(GradeLevelService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets the list of topics by gradelevel id.
        /// </summary>
        /// <returns><see cref="List{TopicDto}"/></returns>
        [HttpGet("{id}/topics")]
        public IActionResult Get(int id) => Ok(service.getTopics(id));

        /// <summary>
        /// Get gradelevel by id
        /// </summary>
        /// <returns><see cref="GradeLevelDto"/></returns>
        /// <response code="200">Return gradelevel by id</response>
        /// <response code="404">When not found gradelevel</response> 
        [HttpGet("{id}", Name = "GradeById")]
        public IActionResult GetProfile(int id) => Ok(service.Get(id));


        /// <summary>
        /// Create new gradelevel
        /// </summary>
        /// <returns><see cref="GradeLevelDto"/></returns>
        /// <response code="201">Return gradelevel by id</response>
        /// <response code="404">When not found gradelevel</response> 
        [HttpPost]
        public IActionResult Add(GradeLevelCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var addedGrade = service.Add(dto);

                return CreatedAtRoute("GradeById", new { id = addedGrade.Id }, addedGrade);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GradeLevelCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                service.Update(id, dto);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
