using JobSearch.Domain.Entities;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Application.Contracts.Persistence.Repositories;

public interface IJobRepository : IRepository<Job, Guid>
{
}