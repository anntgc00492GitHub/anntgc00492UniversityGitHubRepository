using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492University.Data.Infrastructure;
using Anntgc00492University.Data;

namespace anntgc00492University.Data.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        private Anntgc00492UniversityDbContext dbContext;

        public Anntgc00492UniversityDbContext Init()
        {
            return dbContext ?? (dbContext = new Anntgc00492UniversityDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
