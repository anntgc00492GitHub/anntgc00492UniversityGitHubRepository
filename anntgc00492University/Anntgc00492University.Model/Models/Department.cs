using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anntgc00492University.Model.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [StringLength(50,MinimumLength = 5,ErrorMessage = "Deparement name must be between 5 and 50 characters")]
        public string Name { get; set; }
        [DataType(DataType.Currency),Column(TypeName = "money")]
        public decimal Budget { get; set; }
        [Display(Name = "Start Date"),DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }
        public virtual Instructor AdmInstructor { get; set; }
        public virtual ICollection<Course> Courses { get; set; }        
    }
}
