using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Core.Domain
{
    public class Grade
    {
        public int Id { get; set; } 
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
