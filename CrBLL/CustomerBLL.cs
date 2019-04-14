
using Models;
using MongoDbAccess;
using System.Collections.Generic;
using System.Linq;

namespace CrBLL
{
    public class CustomerBLL
    {
        public virtual IEnumerable<ICustomer> GetAll()
        {
            var context = new DbContextFactory().GetDbContext();
            return context.Customers;
        }
        public virtual IEnumerable<ICustomer> FindByName(string name)
        {
            var context = new DbContextFactory().GetDbContext();            
            return context.Customers.Where(c => (c.CompanyName + "").Contains(name));            
        }

        public virtual IEnumerable<ICustomer> Find(string id)
        {
            var context = new DbContextFactory().GetDbContext();
            return context.Customers.Where(c => (c.Id == id));
        }

        public virtual void Insert(Customer customer)
        {
            var context = new DbContextFactory().GetDbContext();
            context.Insert(customer);
        }

        public virtual void Delete(string id)
        {
            var context = new DbContextFactory().GetDbContext();
            var ids = id.Split(',');
            if (ids.Length > 1)
            {
                var customers = new List<ICustomer>();
                foreach (var lId in ids)
                {
                    customers.Add(new Customer(lId));
                }
                context.DeleteMany(customers);
            }
            else
            {
                var customer = new Customer(id);                
                context.Delete(customer);
            }            
        }
        public virtual void Update(Customer customer)
        {
            var context = new DbContextFactory().GetDbContext();
            context.Update(customer);
        }


    }
}
