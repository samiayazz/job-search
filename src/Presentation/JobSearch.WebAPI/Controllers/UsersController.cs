using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.DTOs.Identity;
using JobSearch.WebAPI.Helpers.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService, UserHelper userHelper) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly UserHelper _userHelper = userHelper;

        [HttpGet("token", Name = "GetToken")]
        public async Task<IActionResult> GetTokenAsync([FromQuery] string userNameOrEmail, [FromQuery] string password)
        {
            string token = await _userService.GetTokenAsync(userNameOrEmail, password);
            if (!string.IsNullOrEmpty(token))
                return Ok(token);
            else
                return Problem("Token oluşturulurken bir hata oluştu.");
        }

        [HttpPost("create/{role}", Name = "CreateUser")]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto user, [FromRoute] string role = "worker")
        {
            if (await _userService.CreateAsync(user, role))
                return Ok();
            else
                return Problem("Kullanıcı oluşturulurken bir hata oluştu.");
        }

        [Authorize]
        [HttpGet("remove", Name = "RemoveUser")]
        public async Task<IActionResult> RemoveAsync()
        {
            var user = _userHelper.ResolveUserInToken();

            if (await _userService.RemoveAsync(user))
                return Ok();
            else
                return Problem("Kullanıcı silinirken bir hata oluştu.");
        }
    }
}