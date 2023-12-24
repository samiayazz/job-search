using JobSearch.Application.Contracts.Persistence.Repositories.User;
using JobSearch.Domain.Entities.Identity;
using JobSearch.Persistence.Contexts;
using JobSearch.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Repositories.User;

public class UserRepository : RepositoryBase<AppUser, Guid>, IUserRepository
{
    public UserRepository(JobSearchDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<AppUser> GetByUserNameOrEmailAsync(string userNameOrEmail)
        => await _table
            .Where(x => x.UserName == userNameOrEmail || x.Email == userNameOrEmail)
            .FirstOrDefaultAsync();
}