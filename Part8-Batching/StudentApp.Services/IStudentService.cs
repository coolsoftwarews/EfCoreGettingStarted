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
        Task CreateBatchAsync(List<dtoStudent> students);

        Task<dtoStudent> UpdateAsync(dtoStudent dto);
        Task UpgradeStudentsToNextGradeOption1(int currentGradeId, int nextgradeId);
        Task UpgradeStudentsToNextGradeOption2(int currentGradeId, int nextgradeId);

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

        public async Task CreateBatchAsync(List<dtoStudent> students)
        {

            var student = await this._context
                           .Students
                           .TagWith("This is the generated SQL")
                           .FirstOrDefaultAsync(x => x.Id == 1);

            var student2 = await this._context
                                .Students
                                .TagWith("This is the generated SQL")
                                .FirstOrDefaultAsync(x => x.Id == 2);

            await _context.Students.AddRangeAsync(
                            new Student { FirstName = "Student 1", LastName = "Last Name", DOB = DateTime.Now.AddYears(-5), GradeId = 1 },
                            new Student { FirstName = "Student 2", LastName = "Last Name", DOB = DateTime.Now.AddYears(-5), GradeId = 1 },
                            new Student { FirstName = "Student 3", LastName = "Last Name", DOB = DateTime.Now.AddYears(-5), GradeId = 1 },
                            new Student { FirstName = "Student 4", LastName = "Last Name", DOB = DateTime.Now.AddYears(-5), GradeId = 1 }

                );

      
            student.FirstName = "Change to 1";
            student2.FirstName = "Change to 2";


            await this._context.SaveChangesAsync();
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


        public async Task UpgradeStudentsToNextGradeOption1(int currentGradeId, int nextgradeId)
        {

            var students = await this._context
                                       .Students
                                       .TagWith("Get students for current grade")
                                       .Where(x => x.GradeId == currentGradeId)
                                       .ToListAsync();

            students.ForEach(x => x.GradeId = nextgradeId);

            await this._context.SaveChangesAsync();

        }

        public async Task UpgradeStudentsToNextGradeOption2(int currentGradeId, int nextgradeId)
        {
            var sqlUpdate = $"Update Students set gradeId = {nextgradeId} where gradeId = {currentGradeId}";

            var updatedRows = await _context.Database.ExecuteSqlRawAsync(sqlUpdate);

        }
    }
}
