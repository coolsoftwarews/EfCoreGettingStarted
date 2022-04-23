using AutoMapper;
using StudentApp.Core.Domain;
using StudentApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Services.Infrastructure.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Grade, dtoGrade>()
                .ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
                .ForMember(d => d.Name, op => op.MapFrom(s => s.Name));
            CreateMap<dtoGrade, Grade>();


            CreateMap<Course, dtoCourse>();
            CreateMap<dtoCourse, Course>();

            CreateMap<Student, dtoStudent>()
                .ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
                .ForMember(d => d.FullName, op => op.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                .ForMember(d => d.DOB, op => op.MapFrom(s => s.DOB));
            CreateMap<dtoStudent, Student>();

        }
    }
}
