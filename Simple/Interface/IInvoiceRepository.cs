using Simple.Entity;
using Simple.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Interface
{
    public interface IInvoiceRepository:IBaseRepository<Invoice>
    {
        List<Invoice> GetCustomerById(Guid id);
    }
}
