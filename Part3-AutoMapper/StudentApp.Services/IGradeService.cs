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
    public interface IGradeService
    {
        Task<List<Grade>> GetAllAsync();
        Task<Grade> GetByIdAsync(int id);
        Task<Grade> CreateAsync(Grade entity);
    }

    public class GradeService : IGradeService
    {
        private StudentContext _context;

        public GradeService()
        {
            this._context = new StudentContext(); // will change to DI later
        }
        public async Task<Grade> CreateAsync(Grade entity)
        {
            await this._context.Grades.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Grade>> GetAllAsync()
        {
            return await this._context.Grades.ToListAsync();
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            var entity = await this._context.Grades.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}
