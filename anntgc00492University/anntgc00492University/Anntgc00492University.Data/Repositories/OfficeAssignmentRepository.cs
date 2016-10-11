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
    public interface IOfficeAssignmentRepository:IRepository<OfficeAssignment>
    {
        
    }
    class OfficeAssignmentRepository:RepositoryBase<OfficeAssignment>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
