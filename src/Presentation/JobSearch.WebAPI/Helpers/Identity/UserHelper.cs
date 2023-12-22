using System.Security.Claims;
using JobSearch.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.WebAPI.Helpers.Identity;

public static class UserHelper
{
    private static IHttpContextAccessor _httpContextAccessor;
    private static UserManager<AppUser> _userManager;
    public static void Configure(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        => (_httpContextAccessor, _userManager) = (httpContextAccessor, userManager);

    public static AppUser ResolveUserInToken()
    {
        Guid userId = Guid.Empty;
        if (!Guid.TryParse(_httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out userId))
            throw new Exception("Token'daki User'in Id bilgisi çözümlenirken bir hata oluştu.");

        var user = _userManager.Users.Where(x => x.Id == userId).FirstOrDefault();
        if (user == null)
            throw new Exception("Token'daki User bilgisi çözümlenirken bir hata oluştu.");

        return user;
    }
}
