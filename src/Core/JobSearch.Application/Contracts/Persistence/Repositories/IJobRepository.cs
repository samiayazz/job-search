using JobSearch.Domain.Entities;
using JobSearch.Domain.Entities.Job;

namespace JobSearch.Application.Contracts.Persistence.Repositories;

public interface IJobRepository : IRepository<Job, Guid>
{
}