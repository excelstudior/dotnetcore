using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Entity.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class 
    {

        protected BaseDbContext _context;

        public BaseRepository()
        {
            _context = DbContextFatory.Create();
        }

       //protected static ServiceProvider ServiceProvider { get => serviceProvider; set => serviceProvider = value; }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        //public virtual void Edit(T entity)
        //{
        //    _context.Entry(entity).State = System.Data.EntityState.Modified;
        //}

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
