using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anntgc00492University.Model.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [StringLength(50,MinimumLength = 5,ErrorMessage = "Titlte must be between 5 and 50 characters")]
        public string Titlte { get; set; }
        [Range(0,10)]
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
