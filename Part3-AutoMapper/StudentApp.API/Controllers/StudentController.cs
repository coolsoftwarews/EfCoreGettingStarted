using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;
using StudentApp.Services;

namespace StudentApp.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(
                        IStudentService studentService
            )
        {
            this._studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return  Ok(await this._studentService.GetAllAsync());
        }

        [HttpGet("{id}", Name ="GetStudentById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await this._studentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
              await this._studentService.CreateAsync(student);
              return Ok(student);

        }

    }
}
