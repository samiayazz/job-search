using JobSearch.Application.DTOs.Identity;

namespace JobSearch.Application.Contracts.Infrastructure.Services;

public interface IUserService
{
    public Task<bool> CreateAsync(UserCreateDto userCreateDto, string role);
    public Task<string> GetTokenAsync(string userNameOrEmail, string password);
}