using System.Collections.Generic;
using System.Linq;
using CrBLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CustomerRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    { 
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<ICustomer> Get()
        {
            var customers = new CustomerBLL().GetAll();
            return customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public ICustomer Get(string id)
        {
            var customer = new CustomerBLL().Find(id).FirstOrDefault();
            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromForm]Customer customer)
        {   
            new CustomerBLL().Insert(customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(string id, [FromForm] Customer customer)
        {
            customer.Id = id;
            new CustomerBLL().Update(customer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            new CustomerBLL().Delete(id);
        }
    }
}
