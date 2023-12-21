namespace JobSearch.Application.Contracts.Infrastructure.Services;

public interface IUserService
{
    public Task<bool> RegisterAsync(UserRegisterDto userRegisterDto, string role);
}