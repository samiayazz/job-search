using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.Contracts.Persistence.Repositories.JobPost;
using JobSearch.Application.Contracts.Persistence.Repositories.User;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Infrastructure.Services.JobPost;

public class JobService(IJobRepository repository, IUserRepository userRepository, IMapper mapper) : IJobService
{
    public async Task<ICollection<Job>?> GetByKeyword(string keyword, string location)
    {
        ArgumentException.ThrowIfNullOrEmpty(keyword, nameof(keyword));
        ArgumentException.ThrowIfNullOrEmpty(location, nameof(location));

        return await repository.GetAllAsync(x =>
            x.Company.Address.FullAddress != null &&
            x.Title.ToLower().Contains(keyword.ToLower()) &&
            x.Company.Address.FullAddress.ToLower().Contains(location.ToLower()));
    }

    public async Task<bool> CreateAsync(Guid userId, JobCreateDto jobCreateDto)
    {
        var user = await userRepository.FindByIdAsync(userId);
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        if (user.Role.Name is not "Recruiter" and not "Founder")
            throw new Exception("Sadece 'Recruiter' veya 'Founder' rolündeki üyeler, yeni bir iş ilanı oluşturabilir.");

        var mappedJob = mapper.Map<Job>(jobCreateDto);
        mappedJob.CreatedById = userId;

        return await repository.CreateAsync(mappedJob);
    }
}