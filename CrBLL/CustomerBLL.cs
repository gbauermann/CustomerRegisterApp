
using Models;
using MongoDbAccess;
using System.Collections.Generic;
using System.Linq;

namespace CrBLL
{
    public class CustomerBLL
    {
        public IEnumerable<ICustomer> GetAll()
        {
            var context = new DbContextFactory().GetDbContext();
            return context.Customers;
        }
        public IEnumerable<ICustomer> FindByName(string name)
        {
            var context = new DbContextFactory().GetDbContext();            
            return context.Customers.Where(c => (c.CompanyName + "").Contains(name));            
        }

        public IEnumerable<ICustomer> Find(string id)
        {
            var context = new DbContextFactory().GetDbContext();
            return context.Customers.Where(c => (c.Id == id));
        }

        public void Insert(Customer customer)
        {
            var context = new DbContextFactory().GetDbContext();
            context.Insert(customer);
        }

        public void Delete(string id)
        {
            var customer = new Customer(id);
            var context = new DbContextFactory().GetDbContext();
            context.Delete(customer);
        }
        public void Update(Customer customer)
        {
            var context = new DbContextFactory().GetDbContext();
            context.Update(customer);
        }


    }
}
