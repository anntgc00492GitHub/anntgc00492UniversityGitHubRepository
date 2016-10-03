using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anntgc00492University.Model.Abstract;

namespace Anntgc00492University.Model.Models
{
    public class Student:Person
    {
        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true),Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
