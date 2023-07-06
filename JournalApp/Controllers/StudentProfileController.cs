using LogicLayer.Dto.studentProfile;
using LogicLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfileController : ControllerBase
    {
        private readonly StudentProfileService service;

        public StudentProfileController(StudentProfileService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get profile by id
        /// </summary>
        /// <returns><see cref="ProfileDto"/></returns>
        /// <response code="200">Return profile by id</response>
        /// <response code="404">When not found profile</response> 
        [HttpGet("{id}", Name = "ProfileById")]
        public IActionResult GetProfile(int id) => Ok(service.Get(id));


        [HttpPut("{id}")]
        public IActionResult Update(int id, ProfileCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                service.Update(id, dto);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
