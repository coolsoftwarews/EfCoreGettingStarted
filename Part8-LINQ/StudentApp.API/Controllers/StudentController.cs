using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;
using StudentApp.Services;
using StudentApp.Services.DTOs;

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
            return Ok(await this._studentService.GetAllAsync());
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await this._studentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] dtoStudent dto)
        {
            await this._studentService.CreateAsync(dto);

            return Ok(dto);
        }

        
        [HttpPost("batch", Name = "CreateBatch")]
        public async Task<IActionResult> CreateBatch()
        {
            await this._studentService.CreateBatchAsync(new List<dtoStudent>());

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] dtoStudent dto)
        {
            await this._studentService.UpdateAsync(dto);

            return Ok(dto);
        }

    }
}
