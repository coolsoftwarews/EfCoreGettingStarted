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
                    new Student { Id = 1, GradeId= 1, FirstName="Jonny", LastName="Smith", DOB=DateTime.Now.AddYears(-6)},
                    new Student { Id = 2, GradeId = 1, FirstName = "Sally", LastName = "White", DOB = DateTime.Now.AddYears(-6) }
                );
        }
    }
}
