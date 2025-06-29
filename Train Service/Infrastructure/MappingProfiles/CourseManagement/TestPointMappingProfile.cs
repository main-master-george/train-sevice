using AutoMapper;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Domain;

namespace Infrastructure.MappingProfiles.CourseManagement;

public class TestPointMappingProfile : Profile
{
    public TestPointMappingProfile()
    {
        CreateMap<TestPoint, TestPointDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt
                .MapFrom(src => src.Text))
            .ForMember(dest => dest.IsValid, opt => opt
                .MapFrom(src => src.IsValid));

        CreateMap<CreationTestPointDto, TestPoint>()
            .ForMember(dest => dest.TestId, opt => opt
                .MapFrom(src => src.PageId))
            .ForMember(dest => dest.Text, opt => opt
                .MapFrom(src => src.Text))
            .ForMember(dest => dest.IsValid, opt => opt
                .MapFrom(src => src.IsValid));
    }
}