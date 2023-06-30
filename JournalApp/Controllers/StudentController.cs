using LogicLayer.Dto.student;
using LogicLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService service;

        public StudentController(StudentService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get the list of students.
        /// </summary>
        /// <returns><see cref="List{StudentDto}"/></returns>
        [HttpGet]
        public IActionResult Get() => Ok(service.Get());

        /// <summary>
        /// Get student by id
        /// </summary>
        /// <returns><see cref="StudentDto"/></returns>
        /// <response code="200">find student</response>
        /// <response code="404">When not found student</response> 
        [HttpGet("{id}", Name = "StudentById")]
        public IActionResult GetProfile(int id) => Ok(service.Get(id));

        /// <summary>
        /// Create new student
        /// </summary>
        /// <returns><see cref="StudentDto"/></returns>
        /// <response code="201">Return student by id</response>
        /// <response code="404">When not found student</response> 
        [HttpPost]
        public IActionResult Add(StudentCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var addedStudent = service.Add(dto);
                return CreatedAtRoute("StudentById", new { id = addedStudent.Id }, addedStudent);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentCreateDto dto)
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
