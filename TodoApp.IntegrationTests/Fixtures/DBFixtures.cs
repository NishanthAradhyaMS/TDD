namespace TodoApp.IntegrationTests.Fixtures
{
    public class DBFixtures : IDisposable
    {
        public MongoDBSetting DbContextSettings { get; }
        public MongoDbContext DbContext { get; }
        public static Random rnd = new Random();

        public DBFixtures() 
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connString = config.GetSection("MongoDB").GetSection("ConnectionURI").Value;
            var collection = config.GetSection("MongoDB").GetSection("CollectionName").Value;
            var dbName = $"test_db_{rnd.Next()}";

            this.DbContextSettings = new MongoDBSetting();
            this.DbContextSettings.DatabaseName= dbName ;
            this.DbContextSettings.ConnectionURI = connString;
            var settings = Options.Create(new MongoDBSetting { ConnectionURI = connString,DatabaseName=dbName,CollectionName=collection });
            this.DbContext = new MongoDbContext(settings);
        }
        public void Dispose()
        {
            var client = new MongoClient(this.DbContextSettings.ConnectionURI);
            client.DropDatabase(this.DbContextSettings.DatabaseName);
        }
    }
}
