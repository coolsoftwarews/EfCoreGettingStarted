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
        Task<dtoStudent> CreateAsync(dtoStudent dto);
        Task<dtoStudent> UpdateAsync(dtoStudent dto);
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

            var student = await this._context
                                   .Students
                                    //.AsNoTracking()
                                   .TagWith("This is the generated SQL")
                                   .FirstOrDefaultAsync(x => x.Id == id);

            Console.WriteLine("Change Tracker");

            Console.WriteLine(this._context.ChangeTracker.DebugView.ShortView);

   
            return this._mapper.Map<dtoStudent>(student);
        }

        public async Task<dtoStudent> UpdateAsync(dtoStudent dto)
        {

            var student = await this._context
                                   .Students
                                   .TagWith("This is the generated SQL")
                                   .FirstOrDefaultAsync(x => x.Id == dto.Id);


            Console.WriteLine("Change Tracker");

            Console.WriteLine(this._context.ChangeTracker.DebugView.ShortView);

            if (student != null)
            {
                student.FirstName = dto.FirstName;
                student.LastName = dto.LastName;
                

                Console.WriteLine("Change Tracker Updated");
                this._context.ChangeTracker.DetectChanges();
                Console.WriteLine(this._context.ChangeTracker.DebugView.LongView);

                await this._context.SaveChangesAsync();
            }


            return this._mapper.Map<dtoStudent>(student);
        }
    }
}
