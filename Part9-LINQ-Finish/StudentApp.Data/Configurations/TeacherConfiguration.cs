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
    public sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {

            builder.HasData(
                new Teacher { Id= 1, FirstName="Mr. T", LastName="Williams"},
                new Teacher { Id = 2, FirstName = "Ms. A", LastName = "Smith" },
                new Teacher { Id = 3, FirstName = "Ms. W", LastName = "White" },
                new Teacher { Id = 4, FirstName = "Mr. D", LastName = "Doe" }
             );
        }
    }
}
