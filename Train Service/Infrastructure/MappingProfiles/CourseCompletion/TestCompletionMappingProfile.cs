using AutoMapper;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace Infrastructure.MappingProfiles.CourseCompletion;

public class TestCompletionMappingProfile : Profile
{
    public TestCompletionMappingProfile()
    {
        CreateMap<TestDto, TestCompletionDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt
                .MapFrom(src => src.Text))
            .ForMember(dest => dest.Value, opt => opt
                .MapFrom(src => src.Value))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}