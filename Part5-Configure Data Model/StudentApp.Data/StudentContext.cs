using Microsoft.EntityFrameworkCore;
using StudentApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Data
{
    public class StudentContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog = StudentDB");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(x => x.Students)
                .WithMany(x => x.Courses)
                .UsingEntity<CourseStudent>
                        (j => j.HasOne<Student>().WithMany(),
                         j => j.HasOne<Course>().WithMany()
                        )
                        .Property(d => d.JoinedCourseDate).HasDefaultValueSql("getdate()");
                        
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }    

    }
}
