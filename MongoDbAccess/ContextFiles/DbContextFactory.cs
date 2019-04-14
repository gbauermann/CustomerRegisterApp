
namespace MongoDbAccess
{
    public class DbContextFactory
    {

        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        public IBaseDbContext GetDbContext()
        {
            //como só utilizamos mongoDb, retornamos o contexto do mongoDB
            //mas poderia retornar outros
            return getMongoDbContext();

        }

        private IBaseDbContext getMongoDbContext()
        {
            var mongoContext = new MongoDbContext();

            mongoContext.ConnectionString = ConnectionString;
            mongoContext.DatabaseName = DatabaseName;
            mongoContext.IsSSL = IsSSL;

            mongoContext.SetUpSettings();

            return mongoContext;
        }
    }
}
