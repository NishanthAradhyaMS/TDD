using TodoApp.Models;

namespace ToDoApp.Services.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetUserListAsync();
        Task<string> CreteUserAsync(User user);
    }
}
