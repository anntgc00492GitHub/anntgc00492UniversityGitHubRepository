using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anntgc00492University.Data.Infrastructure
{
    public class DbFactory:IDbFactory
    {
        private Anntgc00492UniversityDbContext dbContext;
        public Anntgc00492UniversityDbContext Init()
        {
            return dbContext ?? (dbContext = new Anntgc00492UniversityDbContext());
        }
    }
}
