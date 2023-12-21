using JobSearch.Application;
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

        [HttpPost("register/{role}", Name = "Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto user, [FromRoute] string role = "worker")
        {
            if (await _userService.RegisterAsync(user, role))
                return Ok();
            else
                return Problem("Kullanıcı oluşturulurken bir hata oluştu.");
        }
    }
}