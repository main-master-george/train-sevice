using AutoMapper;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace Infrastructure.MappingProfiles.CourseCompletion;

public class PageCompletionMappingProfile : Profile
{
    public PageCompletionMappingProfile()
    {
        CreateMap<PageDto, PageCompletionDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}