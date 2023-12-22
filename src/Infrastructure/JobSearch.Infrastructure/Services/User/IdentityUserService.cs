using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.DTOs.Identity;
using JobSearch.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JobSearch.Infrastructure.Services.User;

public class IdentityUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
RoleManager<AppRole> roleManager, IMapper mapper, IConfiguration config) : IUserService
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly RoleManager<AppRole> _roleManager = roleManager;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _config = config;

    public async Task<bool> CreateAsync(UserCreateDto userCreateDto, string role)
    {
        Guid? roleId = _roleManager.Roles.Where(x => x.Name.ToLower() == role.ToLower()).FirstOrDefault()?.Id;
        if (roleId == null)
            throw new Exception("'role' parametresi sadece; 'Worker', 'Recruiter', 'Founder' değerlerini alabilir.");

        var mappedUser = _mapper.Map<AppUser>(userCreateDto);
        mappedUser.RoleId = (Guid)roleId;
        var result = await _userManager.CreateAsync(mappedUser);
        return result.Succeeded;
    }

    public async Task<string> GetTokenAsync(string userNameOrEmail, string password)
    {
        var user = await this.GetByUserNameOrEmailAsync(userNameOrEmail);

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded)
            throw new Exception("Girilen kullanıcı adı veya email ve parola bilgileri ile eşleşen bir kullanıcı bulunamadı.");

        return this.CreateJwtTokenAsync(user);
    }

    private async Task<AppUser> GetByUserNameOrEmailAsync(string userNameOrEmail)
        => await _userManager.FindByNameAsync(userNameOrEmail) ?? await _userManager.FindByEmailAsync(userNameOrEmail);

    private string CreateJwtTokenAsync(AppUser user)
    {

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, user.Role.Name)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtToken:SecurityKey"]));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var lifeTime = DateTime.Now.AddMinutes(Convert.ToInt32(_config["JwtToken:LifeTimeMinute"]));

        var token = new JwtSecurityToken(
            claims: claims,
            issuer: _config["JwtToken:Issuer"],
            audience: _config["JwtToken:Audience"],
            signingCredentials: signingCredentials,
            expires: lifeTime);

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        return jwtSecurityTokenHandler.WriteToken(token);
    }
}