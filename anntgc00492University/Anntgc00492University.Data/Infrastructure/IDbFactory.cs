using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anntgc00492University.Data.Infrastructure
{
    public interface IDbFactory
    {
        Anntgc00492UniversityDbContext Init();
    }
}
