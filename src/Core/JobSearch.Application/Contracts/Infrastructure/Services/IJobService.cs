using JobSearch.Application.DTOs.JobPost;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Application.Contracts.Infrastructure.Services
{
    public interface IJobService
    {
        public Task<ICollection<Job>?> GetByKeywordAndLocation(string keyword, string location,
            string? department = null, string? workType = null, string? workModel = null);

        public Task<bool> CreateAsync(Guid userId, JobCreateDto jobCreateDto);
    }
}