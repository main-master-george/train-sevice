using AutoMapper;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace Infrastructure.MappingProfiles.CourseCompletion;

public class TextCompletionMappingProfile : Profile
{
    public TextCompletionMappingProfile()
    {
        CreateMap<TextDto, TextCompletionDto>()
            .ForMember(dest => dest.Data, opt => opt
                .MapFrom(src => src.Data))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}