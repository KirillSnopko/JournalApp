using Microsoft.AspNetCore.Mvc;
using LogicLayer.Service;
using LogicLayer.Dto.subject;

namespace JournalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService service;

        public SubjectController(SubjectService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets the list of all subjects.
        /// </summary>
        /// <returns><see cref="List{SubjectDto}"/></returns>
        [HttpGet]
        public IActionResult Get() => Ok(service.Get());

        /// <summary>
        /// Get subject by id
        /// </summary>
        /// <returns><see cref="SubjectDto"/></returns>
        /// <response code="200">Return subject by id</response>
        /// <response code="404">When not found subject</response> 
        [HttpGet("{id}", Name = "SubjectById")]
        public IActionResult GetProfile(int id) => Ok(service.Get(id));

        /// <summary>
        /// Create new subject
        /// </summary>
        /// <returns><see cref="SubjectDto"/></returns>
        /// <response code="201">Return subject by id</response>
        /// <response code="404">When not found subject</response> 
        [HttpPost]
        public IActionResult Add(SubjectCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var addedSubject = service.Add(dto);
                return CreatedAtRoute("SubjectById", new { id = addedSubject.Id }, addedSubject);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SubjectCreateDto dto)
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
