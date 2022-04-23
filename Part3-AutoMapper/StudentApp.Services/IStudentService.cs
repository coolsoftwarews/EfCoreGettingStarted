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
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student entity);
    }

    public class StudentService : IStudentService
    {
        private StudentContext _context;

        public StudentService()
        {
            this._context = new StudentContext(); // will change to DI later
        }
        public async Task<Student> CreateAsync(Student entity)
        {
            await this._context.Students.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await this._context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var entity = await this._context.Students.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}
