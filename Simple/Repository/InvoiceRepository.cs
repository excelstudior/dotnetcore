using Simple.Entity;
using Simple.Entity.Base;
using Simple.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Repository
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(BaseDbContext baseDbContext):base(baseDbContext)
        {

        }
        public List<Invoice> GetCustomerById(Guid id)
        {
            return _context.Set<Invoice>().Where(i => i.CustomerId == id).ToList();
        }
    }
}
