using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Text.Json;
using TodoApp.Models;
using ToDoApp.Models;
using ToDoApp.Repository;
using ToDoApp.Repository.DBContext;

namespace TDDPOC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDbContext _dbContext;

        public UserRepository(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<string> CreteUserAsync(User user)
        {
            user.CreatedDateTime = DateTime.Now;
            var data = _dbContext.CreteUserAsync(user);
            return data;
        }

        public Task<List<User>> GetUsersAsync()
        {            
            var data = _dbContext.GetUsersAsync();
            return data;
            
        }
    }
}
