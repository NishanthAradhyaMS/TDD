using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TodoApp.Models;
using ToDoApp.Models;

namespace ToDoApp.Repository.DBContext
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoCollection<User> _userCollection;

        public MongoDbContext(IOptions<MongoDBSetting> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _userCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<string> CreteUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
            return user.Id;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
