
using TodoApp.Models;

namespace ToDoApp.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<string> CreteUserAsync(User user);

    }
}
