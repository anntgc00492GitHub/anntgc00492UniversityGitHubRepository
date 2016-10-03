using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anntgc00492University.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> dbSet;
        protected IDbFactory DbFactory { get;}

        private Anntgc00492UniversityDbContext dataContext;
        protected Anntgc00492UniversityDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }


        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public T Delete(int id)
        {
            return dbSet.Remove(dbSet.Find(id));
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }
            return dataContext.Set<T>().AsQueryable();
        }

    }
}
