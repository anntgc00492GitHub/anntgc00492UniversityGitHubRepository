using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anntgc00492University.Model.Models
{
    public class OfficeAssigment
    {
        [Key,ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        [StringLength(50,MinimumLength = 5,ErrorMessage = "Location can not be longer than 50 characters")]
        public string Location { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
