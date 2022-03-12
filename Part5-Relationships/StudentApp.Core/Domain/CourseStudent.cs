using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Core.Domain
{
    public class CourseStudent
    {
        public int CoursesId { get; set; }
        public int StudentsId { get; set; }

        public DateTime JoinedCourseDate { get; set; }
        public DateTime? TerminateCourseDate { get; set; }
    }
}
