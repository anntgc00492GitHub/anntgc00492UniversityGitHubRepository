using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Model.Models;

namespace Anntgc00492University.Data.Repositories
{
    public class StudentRepository:RepositoryBase<Student>
    {
        public StudentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
