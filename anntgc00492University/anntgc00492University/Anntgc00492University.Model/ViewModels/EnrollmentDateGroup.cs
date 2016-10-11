using System;
using System.ComponentModel.DataAnnotations;

namespace Anntgc00492University.Model.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.DateTime)]
        public DateTime? EnrollmentDate { get; set; }
        public int StudentCount { get; set; }
    }
}