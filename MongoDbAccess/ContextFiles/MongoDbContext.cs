using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDbAccess
{
    public class MongoDbContext : IBaseDbContext
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }

        private IMongoDatabase database;

        /// <summary>
        /// Construtor interno para que a decisão do contexto fique por conta da factory class DbContextFactory
        /// </summary>
        internal MongoDbContext()
        {

        }

        internal void SetUpSettings()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }

                var mongoClient = new MongoClient(settings);
                database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível estabelecer conexão ao servidor de banco de dados", ex);
            }
        }

        public ICollection<Customer> Customers => getRecords<Customer>("Customer");


        public void Insert<T>(T item)
        {            
            var collection = database.GetCollection<T>(item.GetType().Name);            
            collection.InsertOneAsync(item);
        }

        public void Update<T>(T item)
        {
            var collection = database.GetCollection<T>(item.GetType().Name);
            var id = ((IMongoModel)item).Id;
            collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), item);
            
        }

        public void Delete<T>(T item)
        {
            var collection = database.GetCollection<T>(item.GetType().Name);
            var id = ((IMongoModel)item).Id;

            collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }

        private ICollection<T> getRecords<T>(string collectionName)
        {
            var records = database.GetCollection<T>(collectionName);
            return records.Find(m => true).ToListAsync().Result;
        }
  
    }
}
