using LogicLayer.Dto.topic;
using LogicLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicService service;

        public TopicController(TopicService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets the list of all topics.
        /// </summary>
        /// <returns><see cref="List{TopicDto}"/></returns>
        [HttpGet]
        public IActionResult Get() => Ok(service.Get());

        /// <summary>
        /// Get topic by id
        /// </summary>
        /// <returns><see cref="TopicDto"/></returns>
        /// <response code="200">Return topic by id</response>
        /// <response code="404">When not found topic</response> 
        [HttpGet("{id}", Name = "TopicById")]
        public IActionResult GetProfile(int id) => Ok(service.Get(id));


        /// <summary>
        /// Create new topic
        /// </summary>
        /// <returns><see cref="TopicDto"/></returns>
        /// <response code="201">Return topic by id</response>
        /// <response code="404">When not found topic</response> 
        [HttpPost]
        public IActionResult Add(TopicCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var addedTopic = service.Add(dto);
                return CreatedAtRoute("TopicById", new { id = addedTopic.Id }, addedTopic);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TopicCreateDto dto)
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
