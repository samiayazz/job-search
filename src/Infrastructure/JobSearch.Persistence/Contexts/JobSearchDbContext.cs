using JobSearch.Domain.Entities;
using JobSearch.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Contexts;

public class JobSearchDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public JobSearchDbContext(DbContextOptions<JobSearchDbContext> options) : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
}