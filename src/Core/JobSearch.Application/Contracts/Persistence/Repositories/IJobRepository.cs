using JobSearch.Domain.Entities;

namespace JobSearch.Application.Contracts.Persistence.Repositories;

public interface IJobRepository : IRepository<Job, Guid>
{
}