using MongoDB.Driver;
using TodoApp.Models;

namespace ToDoApp.Repository.DBContext
{
    public interface IMongoDbContext
    {
        Task<List<User>> GetUsersAsync();
        Task<string> CreteUserAsync(User user);

    }
}
