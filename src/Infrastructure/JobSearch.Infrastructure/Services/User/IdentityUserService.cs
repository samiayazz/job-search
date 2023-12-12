using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Infrastructure.Services.User;

public class IdentityUserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public IdentityUserService(UserManager<AppUser> userManager)
        => _userManager = userManager;

    public ICollection<AppUser> GetAllUsers()
    {
        return _userManager.Users.ToList();
    }
}