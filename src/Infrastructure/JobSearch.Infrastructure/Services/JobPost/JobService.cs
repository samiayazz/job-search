using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.Contracts.Persistence.Repositories.JobPost;
using JobSearch.Application.Contracts.Persistence.Repositories.User;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Infrastructure.Services.JobPost;

public class JobService(IJobRepository repository, IUserRepository userRepository, IMapper mapper) : IJobService
{
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