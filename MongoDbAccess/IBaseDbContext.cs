using Models;
using System;
using System.Collections.Generic;

namespace MongoDbAccess
{
    public interface IBaseDbContext
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        bool IsSSL { get; set; }

        ICollection<Customer> Customers { get; }

        void Insert<T>(T item);
        void Update<T>(T item);
        void Delete<T>(T item);
    }
}