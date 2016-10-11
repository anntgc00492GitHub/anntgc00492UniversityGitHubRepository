using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anntgc00492University.Data;

namespace anntgc00492University.Data.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        Anntgc00492UniversityDbContext Init();
    }
}
