using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data.Configurations
{
    public sealed class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.HasData(
                    new CourseStudent { CoursesId = 1, StudentsId = 1 },
                    new CourseStudent { CoursesId = 2, StudentsId = 1 },
                    new CourseStudent { CoursesId = 1, StudentsId = 2 },
                    new CourseStudent { CoursesId = 2, StudentsId = 2 }
                );           
        }
    }
}
