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
        Task<dtoStudent> GetByIdAsync(int id);
        Task<dtoStudent> CreateAsync(dtoStudent entity);
    }

    public class StudentService : IStudentService
    {
        private StudentContext _context;
        private IMapper _mapper;

        public StudentService(
                              IMapper mapper
            )
        {
            this._context = new StudentContext(); // will change to DI later

            this._mapper = mapper;
        }
        public async Task<dtoStudent> CreateAsync(dtoStudent dto)
        {
            var entity = this._mapper.Map<Student>(dto);

            await this._context.Students.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return dto;
        }

        public async Task<List<dtoStudent>> GetAllAsync()
        {
            var students = await this._context
                                    .Students
                                    .ToListAsync();

            return this._mapper.Map<List<dtoStudent>>(students);
        }

        public async Task<dtoStudent> GetByIdAsync(int id)
        {
            var dto = await this._context
                                    .Grades
                                    .ProjectTo<dtoStudent>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync(x => x.Id == id);


            return dto;
        }
    }
}
