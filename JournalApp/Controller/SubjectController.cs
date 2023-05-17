using Microsoft.AspNetCore.Mvc;
using LogicLayer.Service;
using LogicLayer.Dto;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService subjectService;

        public SubjectController(SubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        /// <summary>
        /// Gets the list of all subjects.
        /// </summary>
        /// <returns><see cref="List{SubjectDto}"/></returns>


        [HttpGet]
        public IActionResult Get() => Ok(subjectService.Get());

        /// <summary>
        /// Get subject by id
        /// </summary>
        /// <returns><see cref="SubjectDto"/></returns>
        /// <response code="200">Return subject by id</response>
        /// <response code="404">When not found subject</response> 
        [HttpGet("{id}", Name = "SubjectById")]
        public IActionResult GetProfile(int id) => Ok(subjectService.Get(id));


        /// <summary>
        /// Create new subject
        /// </summary>
        /// <returns><see cref="SubjectDto"/></returns>
        /// <response code="201">Return subject by id</response>
        /// <response code="404">When not found subject</response> 
        [HttpPost]
        public IActionResult Add(SubjectCreateDto dto)
        {
            var addedSubject = subjectService.Create(dto);
            return CreatedAtRoute("SubjectById", new { id = addedSubject.Id }, addedSubject);
        }

        [HttpPut]
        public IActionResult Update(int id, SubjectCreateDto dto)
        {
            subjectService.Update(id, dto);
            return NoContent();
        }
    }
}
