using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using ToDoApp.Constants;
using ToDoApp.Services.Interface;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route(ApiRoutes.ControllerRouting)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                var result = await _userService.GetUserListAsync();
                if (result.Any())
                {
                    return Ok(result);

                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            try
            {
                if (user == null || string.IsNullOrEmpty(user.FirstName))
                    return BadRequest();

                var id = await _userService.CreteUserAsync(user);

                Uri url = new Uri($"{ApiRoutes.CreatedUrlReference}{id}");
                return Created(url, user);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }

        }
    }
}