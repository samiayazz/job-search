using AutoMapper;
using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Application.Contracts.Persistence.Repositories.JobPost;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Infrastructure.Services.JobPost;

public class JobService(IJobRepository repository, IMapper mapper) : IJobService
{
    private IJobRepository _repository = repository;
    private IMapper _mapper = mapper;

    public async Task<bool> CreateAsync(Guid userId, JobCreateDto jobCreateDto)
    {
        var mappedJob = _mapper.Map<Job>(jobCreateDto);
        mappedJob.CreatedById = userId;

        return await _repository.CreateAsync(mappedJob);
    }
}
