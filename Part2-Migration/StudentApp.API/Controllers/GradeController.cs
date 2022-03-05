using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;

namespace StudentApp.API.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private StudentContext _context;

        public GradeController()
        {
            this._context = new StudentContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _context.Grades.ToListAsync());


        }

        [HttpGet("{id}", Name = "GetGradeById")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await this._context.Grades.FirstOrDefaultAsync(x => x.Id == id));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Grade grade)
        {
            this._context.Grades.Add(grade);
            await this._context.SaveChangesAsync();

            return Ok(grade);
        }
    }
}
