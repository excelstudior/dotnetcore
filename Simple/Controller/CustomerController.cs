using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Simple.Entity;
using Simple.Entity.Base;
using Simple.Interface;
using Simple.Repository;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple.Controller
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
            _invoiceRepository = new InvoiceRepository();
        }

        [HttpGet("invoices")]
        public IActionResult GetCustomers()
        {
            IQueryable<Customer> customers = _customerRepository.GetAll();

            var customer = customers.Where(c => c.Name == "JJ Import").SingleOrDefault();

            List<Invoice> invoices = _invoiceRepository.GetCustomerById(customer.Id);

            var json = JsonConvert.SerializeObject(
                invoices,
                Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling=ReferenceLoopHandling.Ignore});
            return Ok(json);
        }


    }
}
