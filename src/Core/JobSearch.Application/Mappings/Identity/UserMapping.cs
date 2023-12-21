using AutoMapper;
using JobSearch.Domain.Entities.Identity;

namespace JobSearch.Application;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<AppUser, UserRegisterDto>().ReverseMap();
    }
}
