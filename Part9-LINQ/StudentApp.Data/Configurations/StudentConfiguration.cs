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
    public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.HasData(
                    new Student { Id = 1, GradeId= 1, FirstName= "Anthony", LastName= "Walsh", DOB=DateTime.Now.AddYears(-6)},
                    new Student { Id = 2, GradeId = 1, FirstName = "Kevin", LastName = "Mcguire", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 3, GradeId = 1, FirstName = "Rodney", LastName = "Benson", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 4, GradeId = 1, FirstName = "Patrick", LastName = "Lewis", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 5, GradeId = 1, FirstName = "Debbie", LastName = "Green", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 6, GradeId = 1, FirstName = "Jim", LastName = "Collier", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 7, GradeId = 1, FirstName = "Rebecca", LastName = "Schwartz", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 8, GradeId = 1, FirstName = "Brianna", LastName = "Moon", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 9, GradeId = 1, FirstName = "Curtis", LastName = "Jones", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 10, GradeId = 1, FirstName = "Amanda", LastName = "Weber", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 11, GradeId = 2, FirstName = "Melissa", LastName = "Tucker", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 12, GradeId = 2, FirstName = "Steven", LastName = "Ramirez", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 13, GradeId = 2, FirstName = "Tara", LastName = "Hawkins", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 14, GradeId = 2, FirstName = "David", LastName = "Burton", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 15, GradeId = 2, FirstName = "Daniel", LastName = "Hamilton", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 16, GradeId = 2, FirstName = "Tammy", LastName = "Velazquez", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 17, GradeId = 3, FirstName = "Samuel", LastName = "Price", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 18, GradeId = 3, FirstName = "Mikayla", LastName = "Santos", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 19, GradeId = 3, FirstName = "Tammy", LastName = "Stephenson", DOB = DateTime.Now.AddYears(-6) },
                    new Student { Id = 20, GradeId = 3, FirstName = "Michael", LastName = "Manning", DOB = DateTime.Now.AddYears(-6) }
                );
        }
    }
}
