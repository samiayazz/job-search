using AutoMapper;
using JobSearch.Application.DTOs.Identity;
using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Application.Mappings.Identity;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<AppUser, UserCreateDto>().ReverseMap();
    }
}
