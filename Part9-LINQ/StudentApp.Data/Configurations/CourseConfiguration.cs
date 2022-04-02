using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApp.Core.Domain;

namespace StudentApp.Data.Configurations
{
    public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
    
            builder.HasMany(x => x.Students)
              .WithMany(x => x.Courses)
              .UsingEntity<CourseStudent>
                      (j => j.HasOne<Student>().WithMany(),
                       j => j.HasOne<Course>().WithMany()
                      )
                      .Property(d => d.JoinedCourseDate).HasDefaultValueSql("getdate()");



            builder.HasData(
                        new Course { Id=1, Name="Maths", Description = "Maths are awesome"},
                        new Course { Id=2, Name="Science", Description = "Big Bang"}
                );

        }
    }
}
