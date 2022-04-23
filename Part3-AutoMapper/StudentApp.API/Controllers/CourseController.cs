using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;
using StudentApp.Services;

namespace StudentApp.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;

        public CourseController(
                        ICourseService courseService
            )
        {
            this._courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await this._courseService.GetAllAsync());


        }

        [HttpGet("{id}", Name = "GetCourseById")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await this._courseService.GetByIdAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Course course)
        {
            await this._courseService.CreateAsync(course);

            return Ok(course);
        }
    }
}
