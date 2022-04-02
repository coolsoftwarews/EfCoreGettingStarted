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
    public sealed class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasData(
                     new Grade { Id = 1, TeacherId= 1, Name = "Grade 1"},
                     new Grade { Id = 2, TeacherId = 2, Name = "Grade 2" },
                     new Grade { Id = 3, TeacherId = 3, Name = "Grade 3" },
                     new Grade { Id = 4, TeacherId = 4, Name = "Grade 4" }
                );
        }
    }
}
