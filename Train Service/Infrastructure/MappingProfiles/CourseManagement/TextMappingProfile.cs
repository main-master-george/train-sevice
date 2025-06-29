using AutoMapper;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Domain;

namespace Infrastructure.MappingProfiles.CourseManagement;

public class TextMappingProfile : Profile
{
    public TextMappingProfile()
    {
        CreateMap<Text, TextDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Data, opt => opt
                .MapFrom(src => src.Data))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));

        CreateMap<CreationTextDto, Text>()
            .ForMember(dest => dest.PageId, opt => opt
                .MapFrom(src => src.PageId))
            .ForMember(dest => dest.Data, opt => opt
                .MapFrom(src => src.Data))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}