using JournalApp.Logic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JournalApp.Controller
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
