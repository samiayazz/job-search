using JobSearch.Application.DTOs.Identity;
using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Application.Contracts.Infrastructure.Services;

public interface IUserService
{
    public Task<AppUser> FindByIdAsync(Guid id);
    public Task<bool> CreateAsync(UserModifyDto userModifyDto, string role);
    public Task<bool> UpdateAsync(Guid userId, UserModifyDto userModifyDto);
    public Task<bool> RemoveByIdAsync(Guid id);
    public Task<string> GetTokenAsync(string userNameOrEmail, string password);
}