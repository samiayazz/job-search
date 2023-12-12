using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Application.Contracts.Infrastructure.Services;

public interface IUserService
{
    public ICollection<AppUser> GetAllUsers();
}