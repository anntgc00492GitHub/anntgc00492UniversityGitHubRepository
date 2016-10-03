using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anntgc00492University.Data.Infrastructure;

namespace Anntgc00492University.Data.Repositories
{
    public class InstructorRepository:RepositoryBase<InstructorRepository>
    {
        public InstructorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
