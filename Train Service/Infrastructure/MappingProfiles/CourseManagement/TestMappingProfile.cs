using AutoMapper;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Domain;

namespace Infrastructure.MappingProfiles.CourseManagement;

public class TestMappingProfile : Profile
{
    public TestMappingProfile()
    {
        CreateMap<Test, TestDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, opt => opt
                .MapFrom(src => src.Text))
            .ForMember(dest => dest.Value, opt => opt
                .MapFrom(src => src.Value))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));

        CreateMap<CreationTestDto, Test>()
            .ForMember(dest => dest.PageId, opt => opt
                .MapFrom(src => src.PageId))
            .ForMember(dest => dest.Text, opt => opt
                .MapFrom(src => src.Text))
            .ForMember(dest => dest.Value, opt => opt
                .MapFrom(src => src.Value))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}