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
using Simple.Dependency;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple.Controller
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private ICustomerRepository _customerRepository;
        private IInvoiceRepository _invoiceRepository;
        private BaseDbContext _baseDbContext;
        public CustomerController(ICustomerRepository customerRepository,IInvoiceRepository invoiceRepository,BaseDbContext baseDbContext)
        {
            _customerRepository = customerRepository;
            _invoiceRepository = invoiceRepository;
            _baseDbContext = baseDbContext;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
          
           IQueryable<Customer> customers = _customerRepository.GetAll();
           
           //var customer = customers.Where(c => c.Name == "JJ Import").SingleOrDefault();
           var newCustomer = new Customer
            {
                Id = new Guid(),
                Name = "JJJ Import",
                Reference = "Test"
            };

            _customerRepository.Add(newCustomer);
            var newInvoice = new Invoice
            {
                Id = new Guid(),
                CustomerId = newCustomer.Id
            };
            _invoiceRepository.Add(newInvoice);

            _baseDbContext.SaveChanges();
           //List<Invoice> invoices = _invoiceRepository.GetCustomerById(newCustomer.Id);
           // var json = JsonConvert.SerializeObject(
           //     invoices,
           //     Formatting.Indented
           //     //,
           //     //new JsonSerializerSettings { ReferenceLoopHandling=ReferenceLoopHandling.Ignore}
           //     );
            return Ok();
            
            
        }

        [HttpGet("withToken")]
        [Authorize]
        public IActionResult GetCustomerWithToken()
        {
            var claims = HttpContext.User.Claims;
            return Ok(claims);
        }


    }
}
