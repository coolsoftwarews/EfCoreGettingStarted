using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using StudentApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course entity);
    }

    public class CourseService : ICourseService
    {
        private StudentContext _context;

        public CourseService()
        {
            this._context = new StudentContext(); // will change to DI later
        }
        public async Task<Course> CreateAsync(Course entity)
        {
            await this._context.Courses.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await this._context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var entity =  await this._context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}
