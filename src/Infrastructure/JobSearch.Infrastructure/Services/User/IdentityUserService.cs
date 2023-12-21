using AutoMapper;
using JobSearch.Application;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Infrastructure.Services.User;

public class IdentityUserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper) : IUserService
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly RoleManager<AppRole> _roleManager = roleManager;
    private readonly IMapper _mapper = mapper;

    public async Task<bool> RegisterAsync(UserRegisterDto userRegisterDto, string role)
    {
        Guid? roleId = _roleManager.Roles.Where(x => x.Name.ToLower() == role.ToLower()).FirstOrDefault()?.Id;
        if (roleId == null)
            throw new Exception("'role' parametresi sadece; 'Worker', 'Recruiter', 'Founder' değerlerini alabilir.");

        var mappedUser = _mapper.Map<AppUser>(userRegisterDto);
        mappedUser.RoleId = (Guid)roleId;
        var result = await _userManager.CreateAsync(mappedUser);
        return result.Succeeded;
    }
}