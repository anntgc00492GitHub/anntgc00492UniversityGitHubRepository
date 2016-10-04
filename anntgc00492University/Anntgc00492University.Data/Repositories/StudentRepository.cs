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
    public interface IStudentRepository:IRepository<Student>
    {

    }
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
        
    }
}
