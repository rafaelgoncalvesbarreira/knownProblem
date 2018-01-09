using System;
using System.Collections.Generic;
using System.Text;

namespace KnownProblem.Data.Repository
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> GetAll(Func<T, bool> query = null);
    }
}
