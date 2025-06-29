using AutoMapper;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Domain;

namespace Infrastructure.MappingProfiles.CourseManagement;

public class ModuleMappingProfile : Profile
{
    public ModuleMappingProfile()
    {
        CreateMap<Module, ModuleDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Header, opt => opt
                .MapFrom(src => src.Header))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));

        CreateMap<CreationModuleDto, Module>()
            .ForMember(dest => dest.CourseId, opt => opt
                .MapFrom(src => src.CourseId))
            .ForMember(dest => dest.Header, opt => opt
                .MapFrom(src => src.Header))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description))
            .ForMember(dest => dest.Number, opt => opt
                .MapFrom(src => src.Number));
    }
}