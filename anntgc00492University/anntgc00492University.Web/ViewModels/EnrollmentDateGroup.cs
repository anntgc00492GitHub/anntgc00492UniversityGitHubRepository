using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace anntgc00492University.Web.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.DateTime)]
        public DateTime? EnrollmeTime { get; set; }
        public int StudentCount { get; set; }
    }
}