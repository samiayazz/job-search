using JobSearch.Application.DTOs.JobPost;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Application.Contracts.Infrastructure.Services;

public interface IJobService
{
    public Task<ICollection<Job>?> GetByKeyword(string keyword, string location);
    public Task<bool> CreateAsync(Guid userId, JobCreateDto jobCreateDto);
}