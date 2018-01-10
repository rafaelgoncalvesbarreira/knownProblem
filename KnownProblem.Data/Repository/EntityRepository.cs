using KnownProblem.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KnownProblem.Data.Entity;

namespace KnownProblem.Data.Repository
{
    public class EntityRepository<T> : IRepository<T> where T: BaseEntity
    {
        private DbContext _context;
        public EntityRepository(DbContext context)
        {
            _context = context;
            context.Set<T>();
        }

        public IEnumerable<T> GetAll(Func<T, bool> query = null)
        {
            if(query != null)
            {
                return _context.Set<T>().Where(query);
            }

            return _context.Set<T>();
        }

        public bool Insert(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                int changes = _context.SaveChanges();
                return changes > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                var changes = _context.SaveChanges();
                return changes > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                int changes = _context.SaveChanges();
                return changes > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
