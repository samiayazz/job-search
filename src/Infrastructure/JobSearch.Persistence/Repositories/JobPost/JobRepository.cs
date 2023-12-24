using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Application.Contracts.Persistence.Repositories.JobPost;
using JobSearch.Domain.Entities.JobPost;
using JobSearch.Persistence.Contexts;
using JobSearch.Persistence.Repositories.Common;

namespace JobSearch.Persistence.Repositories.JobPost;

public class JobRepository : RepositoryBase<Job, Guid>, IJobRepository
{
    public JobRepository(JobSearchDbContext dbContext) : base(dbContext)
    {
    }
}