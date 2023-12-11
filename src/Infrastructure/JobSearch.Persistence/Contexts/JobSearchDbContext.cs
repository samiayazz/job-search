using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Contexts;

public class JobSearchDbContext : DbContext
{
    public JobSearchDbContext(DbContextOptions<JobSearchDbContext> options) : base(options)
    {
    }
}