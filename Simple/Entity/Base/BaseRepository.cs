using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Entity.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class 
    {

        protected BaseDbContext _context;
        //protected IServiceProvider _serviceProvider;
        
        public BaseDbContext Context
        {
            get
            {
                if (_context == null)
                {
                   
                return new BaseDbContext();
                }
                return _context;
            }
        }

       //protected static ServiceProvider ServiceProvider { get => serviceProvider; set => serviceProvider = value; }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = Context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        //public virtual void Edit(T entity)
        //{
        //    _dbContext.Entry(entity).State = System.Data.EntityState.Modified;
        //}

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
