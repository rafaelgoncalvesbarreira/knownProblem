using System;
using System.Collections.Generic;
using System.Text;

namespace KnownProblem.Data.Repository
{
    public interface IRepository<T>
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> GetAll(Func<T, bool> query = null);
    }
}
