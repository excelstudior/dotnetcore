using Simple.Entity;
using Simple.Entity.Base;
using Simple.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simple.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BaseDbContext baseDbContext):base(baseDbContext)
        {

        }
        public Customer GetByName(string name)
        {
            return _context.Set<Customer>().Where(c => c.Name == name).SingleOrDefault();
        }
    }
}
