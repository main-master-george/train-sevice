using AutoMapper;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace Infrastructure.MappingProfiles.CourseCompletion;

public class CourseCompletionMappingProfile : Profile
{
    public CourseCompletionMappingProfile()
    {
        CreateMap<CourseDto, CourseBaseDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description));
    }
}