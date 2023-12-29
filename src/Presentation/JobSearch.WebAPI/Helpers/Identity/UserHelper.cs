using System.Security.Claims;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Domain.Entities.Identity;

namespace JobSearch.WebAPI.Helpers.Identity
{
    public class UserHelper(IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        public AppUser ResolveUserInToken()
        {
            if (!Guid.TryParse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    out var userId))
                throw new Exception("Token'dan User'in Id bilgisi çözümlenirken bir hata oluştu.");

            var user = userService.FindByIdAsync(userId).Result;
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            return user;
        }
    }
}