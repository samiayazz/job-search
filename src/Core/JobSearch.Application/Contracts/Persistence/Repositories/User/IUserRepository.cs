using JobSearch.Application.Contracts.Persistence.Repositories.Common;
using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Application.Contracts.Persistence.Repositories.User;

public interface IUserRepository : IRepository<AppUser, Guid>
{
    public Task<AppUser?> FindByUserNameOrEmailAsync(string userNameOrEmail);
}