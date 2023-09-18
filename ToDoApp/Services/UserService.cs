using TodoApp.Models;
using ToDoApp.Repository;
using ToDoApp.Services.Interface;

namespace ToDoApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _dbService;
        public UserService(IUserRepository mongoDBService)
        {
            _dbService = mongoDBService;
        }

        public async Task<string> CreteUserAsync(User user)
        {
            var data = await _dbService.CreteUserAsync(user);
            return data;
        }

        public async Task<List<User>> GetUserListAsync()
        {
            var data = await _dbService.GetUsersAsync();
            return data;
        }
    }
}
