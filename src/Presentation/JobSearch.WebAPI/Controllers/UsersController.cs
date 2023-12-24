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
        [HttpPost("create/{role}", Name = "CreateUser")]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto user, [FromRoute] string role = "worker")
        {
            var result = await userService.CreateAsync(user, role);
            if (!result)
                return Problem("Kullanıcı oluşturulurken bir hata oluştu.");

            return Ok();
        }

        [Authorize]
        [HttpGet("remove", Name = "RemoveUser")]
        public async Task<IActionResult> RemoveAsync()
        {
            var user = userHelper.ResolveUserInToken();

            var result = await userService.RemoveByIdAsync(user.Id);
            if (!result)
                return Problem("Kullanıcı silinirken bir hata oluştu.");

            return Ok();
        }

        [HttpGet("token", Name = "GetToken")]
        public async Task<IActionResult> GetTokenAsync([FromQuery] string userNameOrEmail, [FromQuery] string password)
        {
            string token = await userService.GetTokenAsync(userNameOrEmail, password);
            if (string.IsNullOrEmpty(token))
                return Problem("Token oluşturulurken bir hata oluştu.");

            return Ok(token);
        }
    }
}