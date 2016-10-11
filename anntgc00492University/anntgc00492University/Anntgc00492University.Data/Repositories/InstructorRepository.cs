using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Model.Models;

namespace Anntgc00492University.Data.Repositories
{
    public interface IInstructorRepository:IRepository<Instructor>
    {
        
    }
    public class InstructorRepository:RepositoryBase<Instructor>, IInstructorRepository
    {
        public InstructorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
