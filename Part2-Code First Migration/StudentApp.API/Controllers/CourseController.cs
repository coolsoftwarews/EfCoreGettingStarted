using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;

namespace StudentApp.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private StudentContext _context;

        public CourseController()
        {
            this._context = new StudentContext();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _context.Grades.ToListAsync());


        }

        [HttpGet("{id}", Name = "GetCourseById")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await this._context.Grades.FirstOrDefaultAsync(x => x.Id == id));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Course course)
        {
            this._context.Courses.Add(course);
            await this._context.SaveChangesAsync();

            return Ok(course);
        }
    }
}
