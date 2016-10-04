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
    public interface IEnrollmentRepository:IRepository<Enrollment>
    {
        
    }
    public class EnrollmentRepository:RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
