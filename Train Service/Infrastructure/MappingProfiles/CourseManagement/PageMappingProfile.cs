using AutoMapper;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Domain;

namespace Infrastructure.MappingProfiles.CourseManagement;

public class PageMappingProfile : Profile
{
    public PageMappingProfile()
    {
        CreateMap<Page, PageDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));

        CreateMap<CreationPageDto, Page>()
            .ForMember(dest => dest.ModuleId, opt => opt
                .MapFrom(src => src.ModuleId))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}