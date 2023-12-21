using AutoMapper;
using JobSearch.Application.DTOs.JobPost;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Application.Mappings.JobPost;

public class JobMapping : Profile
{
    public JobMapping()
    {
        CreateMap<Job, JobCreateDto>().ReverseMap();
    }
}
