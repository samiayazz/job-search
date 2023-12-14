using JobSearch.Domain.Entities.Identity;
using JobSearch.Domain.Entities.Institution;
using JobSearch.Domain.Entities.JobPost;
using JobSearch.Domain.Entities.Location;
using JobSearch.Domain.Entities.WorkPreference;
using JobSearch.Persistence.Configurations.Institution;
using JobSearch.Persistence.Configurations.JobPost;
using JobSearch.Persistence.Configurations.Location;
using JobSearch.Persistence.Configurations.WorkPreference;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Contexts;

public class JobSearchDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public JobSearchDbContext(DbContextOptions<JobSearchDbContext> options) : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Sector> Sectors { get; set; }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public DbSet<WorkType> WorkTypes { get; set; }
    public DbSet<WorkModel> WorkModels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new JobConfiguration());
        builder.ApplyConfiguration(new DepartmentConfiguration());

        builder.ApplyConfiguration(new CompanyConfiguration());
        builder.ApplyConfiguration(new SectorConfiguration());

        builder.ApplyConfiguration(new CountryConfiguration());
        builder.ApplyConfiguration(new ProvinceConfiguration());
        builder.ApplyConfiguration(new AddressConfiguration());

        builder.ApplyConfiguration(new WorkTypeConfiguration());
        builder.ApplyConfiguration(new WorkModelConfiguration());
    }
}