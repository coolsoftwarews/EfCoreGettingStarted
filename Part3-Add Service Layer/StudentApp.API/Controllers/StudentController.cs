using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;

namespace StudentApp.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentContext _context;

        public StudentController()
        {
            this._context = new StudentContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

         var students = await _context.Students
                                    .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}", Name ="GetStudentById")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await this._context.Students.FirstOrDefaultAsync(x => x.Id == id));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
                this._context.Add(student); 

                await this._context.SaveChangesAsync();

                return Ok(student);

        }

    }
}
