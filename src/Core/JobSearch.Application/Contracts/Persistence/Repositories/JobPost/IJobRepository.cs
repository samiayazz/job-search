using JobSearch.Application.Contracts.Persistence.Repositories.Common;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Application.Contracts.Persistence.Repositories.JobPost
{
    public interface IJobRepository : IRepository<Job, Guid>
    {
    }
}