using AutoMapper;
using Infrastructure.Models;
using UserManagementModule.Application.Dtos.Outgoing;

namespace Infrastructure.MappingProfiles;

public class UserManagementMappingProfile : Profile
{
    public UserManagementMappingProfile()
    {
        CreateMap<UserModel, UserDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt
                .MapFrom(src => src.Email));
    }
}