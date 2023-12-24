using JobSearch.Application.DTOs.Identity;
using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Application.Contracts.Infrastructure.Services;

public interface IUserService
{
    public Task<string> GetTokenAsync(string userNameOrEmail, string password);
    public Task<bool> CreateAsync(UserCreateDto userCreateDto, string role);
    public Task<bool> RemoveAsync(AppUser user);
}