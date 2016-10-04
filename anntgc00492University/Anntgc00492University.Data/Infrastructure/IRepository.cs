﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace anntgc00492University.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        T Delete(int id);
        T GetSingleById(int id);
        IEnumerable<T> GetAll(string[] includes = null);
    }
}
