using AutoMapper;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Domain;

namespace Infrastructure.MappingProfiles.CourseManagement;

public class CourseMappingProfile : Profile
{
    public CourseMappingProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description));

        CreateMap<CreationCourseDto, Course>()
            .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description))
            .ForMember(dest => dest.IsVisibleForUsers, opt => opt
                .MapFrom(_ => false));
    }
}