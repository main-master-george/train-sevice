using AutoMapper;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace Infrastructure.MappingProfiles.CourseCompletion;

public class ModuleCompletionMappingProfile : Profile
{
    public ModuleCompletionMappingProfile()
    {
        CreateMap<ModuleDto, ModuleCompletionDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Header, opt => opt
                .MapFrom(src => src.Header))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}