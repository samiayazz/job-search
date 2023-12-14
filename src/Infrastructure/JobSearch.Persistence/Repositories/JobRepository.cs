using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Domain.Entities;
using JobSearch.Domain.Entities.Job;
using JobSearch.Persistence.Contexts;
using JobSearch.Persistence.Repositories.Common;

namespace JobSearch.Persistence.Repositories;

public class JobRepository : RepositoryBase<Job, Guid>, IJobRepository
{
    public JobRepository(JobSearchDbContext dbContext) : base(dbContext)
    {
    }
}