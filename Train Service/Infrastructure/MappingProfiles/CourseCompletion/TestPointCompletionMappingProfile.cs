using AutoMapper;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace Infrastructure.MappingProfiles.CourseCompletion;

public class TestPointCompletionMappingProfile : Profile
{
    public TestPointCompletionMappingProfile()
    {
        CreateMap<TestPointDto, TestPointCompletionDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt
                .MapFrom(src => src.Text));
    }
}