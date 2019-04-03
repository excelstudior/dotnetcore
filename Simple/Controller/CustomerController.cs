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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple.Controller
{
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        [HttpGet()]
        public IActionResult GetCustomers()
        {
            IQueryable<Customer> customers = _customerRepository.GetAll();
            return Ok(customers);
        }


    }
}
