using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Anntgc00492University.Model.Abstract
{
    public interface IPerson
    {
        int ID { get; set; }
        string FirstMidName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
    }
}
