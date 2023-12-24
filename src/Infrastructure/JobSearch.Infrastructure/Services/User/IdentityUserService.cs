using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.Contracts.Persistence.Repositories.User;
using JobSearch.Application.DTOs.Identity;
using JobSearch.Domain.Entities.Identity;
using JobSearch.Infrastructure.Helpers.Encryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JobSearch.Infrastructure.Services.User;

public class IdentityUserService(
    IUserRepository repository,
    SignInManager<AppUser> signInManager,
    RoleManager<AppRole> roleManager,
    IMapper mapper,
    IConfiguration config,
    EncryptionHelper encryptionHelper) : IUserService
{
    public async Task<AppUser> FindByIdAsync(Guid id)
    {
        var user = await repository.FindByIdAsync(id);
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        return user;
    }

    public async Task<bool> CreateAsync(UserCreateDto userCreateDto, string role)
    {
        ArgumentNullException.ThrowIfNull(userCreateDto, nameof(userCreateDto));

        Guid? roleId = roleManager.Roles.SingleOrDefault(x => x.Name.ToLower() == role.ToLower())?.Id;
        if (roleId == null)
            throw new Exception("'Role' parametresi sadece; 'Worker', 'Recruiter' ve 'Founder' değerlerini alabilir.");

        var mappedUser = mapper.Map<AppUser>(userCreateDto);
        mappedUser.RoleId = roleId.Value;
        mappedUser.PasswordHash = encryptionHelper.HashPassword(mappedUser, userCreateDto.Password);

        return await repository.CreateAsync(mappedUser);
    }

    public async Task<bool> RemoveByIdAsync(Guid id)
        => await repository.RemoveByIdAsync(id);

    public async Task<string> GetTokenAsync(string userNameOrEmail, string password)
    {
        var user = await repository.FindByUserNameOrEmailAsync(userNameOrEmail);
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var result = await signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded)
            throw new Exception(
                "Girilen kullanıcı adı veya email ve parola bilgileri ile eşleşen bir kullanıcı bulunamadı.");

        return this.CreateJwtToken(user);
    }

    private string CreateJwtToken(AppUser user)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, user.Role.Name)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtToken:SecurityKey"]!));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var lifeTime = DateTime.Now.AddMinutes(Convert.ToInt32(config["JwtToken:LifeTimeMinute"]!));

        var token = new JwtSecurityToken(
            claims: claims,
            issuer: config["JwtToken:Issuer"]!,
            audience: config["JwtToken:Audience"]!,
            signingCredentials: signingCredentials,
            expires: lifeTime);

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        return jwtSecurityTokenHandler.WriteToken(token);
    }
}