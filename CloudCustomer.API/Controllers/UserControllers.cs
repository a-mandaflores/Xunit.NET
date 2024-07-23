using Microsoft.AspNetCore.Mvc;

namespace CloudCustomer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserControllers: ControllerBase
    {
        private readonly IUsersService _usersService;

        
        public UserControllers(IUsersService usersService) { 
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetResult() 
        {
            var users = await _usersService.GetAllUsers();
            return Ok("all good");
        }
    }
}
