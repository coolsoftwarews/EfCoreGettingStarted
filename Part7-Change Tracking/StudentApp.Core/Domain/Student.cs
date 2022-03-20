using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Core.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public int GradeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public Grade Grade { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();


    }
}
