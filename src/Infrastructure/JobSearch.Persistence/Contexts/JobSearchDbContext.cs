using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Contexts;

public class JobSearchDbContext : DbContext
{
    public JobSearchDbContext(DbContextOptions<JobSearchDbContext> options) : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
}