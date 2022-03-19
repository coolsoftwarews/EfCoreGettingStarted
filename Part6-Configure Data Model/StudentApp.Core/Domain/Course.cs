using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Core.Domain
{
    [Table("Courses", Schema="dbo")]
    public class Course
    {

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]

        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Description { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

    }
}
