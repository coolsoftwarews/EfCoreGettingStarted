using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;
using StudentApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services
{
    public interface IStudentService
    {
        Task<List<dtoStudent>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student entity);
    }

    public class StudentService : IStudentService
    {
        private StudentContext _context;
        private IMapper _mapper;

        public StudentService(IMapper mapper)
        {
            this._context = new StudentContext(); // will change to DI later

            this._mapper = mapper;
        }
        public async Task<Student> CreateAsync(Student entity)
        {
            await this._context.Students.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<dtoStudent>> GetAllAsync()
        {
            return await this._context.Students.ProjectTo<dtoStudent>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var entity = await this._context.Students.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}
