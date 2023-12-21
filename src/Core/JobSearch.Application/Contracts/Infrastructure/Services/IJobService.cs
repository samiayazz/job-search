using JobSearch.Application.DTOs.JobPost;

namespace JobSearch.Application.Contracts.Infrastructure.Services;

public interface IJobService
{
    public Task<bool> CreateAsync(Guid userId, JobCreateDto jobCreateDto);
}
