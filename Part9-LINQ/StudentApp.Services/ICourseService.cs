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
    public interface ICourseService
    {
        Task<List<dtoCourse>> GetAllAsync();
        Task<dtoCourse> GetByIdAsync(int id);
        Task<dtoCourse> CreateAsync(dtoCourse entity);
    }

    public class CourseService : ICourseService
    {
        private StudentContext _context;
        private IMapper _mapper;

        public CourseService(
                              IMapper mapper
            )
        {
            this._context = new StudentContext(); // will change to DI later

            this._mapper = mapper;
        }
        public async Task<dtoCourse> CreateAsync(dtoCourse dto)
        {
            var entity = this._mapper.Map<Course>(dto);

            await this._context.Courses.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return dto;
        }

        public async Task<List<dtoCourse>> GetAllAsync()
        {
            var courses = await this._context
                                    .Courses
                                    .ToListAsync();

            return this._mapper.Map<List<dtoCourse>>(courses);
        }

        public async Task<dtoCourse> GetByIdAsync(int id)
        {
            var dto = await this._context
                                    .Grades
                                    .ProjectTo<dtoCourse>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync(x => x.Id == id);

            return dto;
        }
    }
}
