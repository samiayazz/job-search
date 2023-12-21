using JobSearch.Application.Contracts.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
            => _userService = userService;

        [HttpGet("register", Name = "Register")]
        public async Task<IActionResult> RegisterAsync()
        {
            return Ok(_userService.GetAllUsers());
        }
    }
}