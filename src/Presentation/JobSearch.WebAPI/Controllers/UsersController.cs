using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.DTOs.Identity;
using JobSearch.WebAPI.Helpers.Identity;
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

        [HttpPost("create/{role}", Name = "CreateUser")]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto user, [FromRoute] string role = "worker")
        {
            if (await _userService.CreateAsync(user, role))
                return Ok();
            else
                return Problem("Kullanıcı oluşturulurken bir hata oluştu.");
        }

        [HttpGet("token", Name = "GetToken")]
        public async Task<IActionResult> GetTokenAsync([FromQuery] string userNameOrEmail, [FromQuery] string password)
        {
            string token = await _userService.GetTokenAsync(userNameOrEmail, password);
            if (!string.IsNullOrEmpty(token))
                return Ok(token);
            else
                return Problem("Token oluşturulurken bir hata oluştu.");
        }
    }
}