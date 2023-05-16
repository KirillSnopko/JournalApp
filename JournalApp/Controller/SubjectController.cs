using Microsoft.AspNetCore.Mvc;
using LogicLayer.Service;

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

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await subjectService.Get());
    }
}
