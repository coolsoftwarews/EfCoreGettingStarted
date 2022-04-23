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
    public interface IGradeService
    {
        Task<List<dtoGrade>> GetAllAsync();
        Task<dtoGrade> GetByIdAsync(int id);
        Task<dtoGrade> CreateAsync(dtoGrade dto);
    }

    public class GradeService : IGradeService
    {
        private StudentContext _context;
        private IMapper _mapper;

        public GradeService(
                              IMapper mapper
            )
        {
            this._context = new StudentContext(); // will change to DI later

            this._mapper = mapper;
        }
        public async Task<dtoGrade> CreateAsync(dtoGrade dto)
        {
            var entity = this._mapper.Map<Grade>(dto);

            await this._context.Grades.AddAsync(entity);
            await this._context.SaveChangesAsync();

            return dto;
        }

        public async Task<List<dtoGrade>> GetAllAsync()
        {
            var grades = await this._context
                                    .Grades
                                    .ToListAsync();

            return this._mapper.Map<List<dtoGrade>>(grades);
        }

        public async Task<dtoGrade> GetByIdAsync(int id)
        {
            var dto = await this._context
                                    .Grades
                                    .ProjectTo<dtoGrade>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync(x => x.Id == id);


            return dto;
        }
    }
}
