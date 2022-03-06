using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;
using StudentApp.Services;

namespace StudentApp.API.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private IGradeService _gradeService;

        public GradeController(
                        IGradeService gradeService
            )
        {
            this._gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._gradeService.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetGradeById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await this._gradeService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Grade grade)
        {
            await this._gradeService.CreateAsync(grade);

            return Ok(grade);
        }
    }
}
