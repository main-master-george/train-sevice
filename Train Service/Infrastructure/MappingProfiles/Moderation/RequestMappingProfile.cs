using AutoMapper;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Dtos.Outgoing;
using ModerationModule.Domain;

namespace Infrastructure.MappingProfiles.Moderation;

public class RequestMappingProfile : Profile
{
    public RequestMappingProfile()
    {
        CreateMap<Request, RequestDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.CourseId, opt => opt
                .MapFrom(src => src.CourseId))
            .ForMember(dest => dest.Status, opt => opt
                .MapFrom(src => src.Status.ToString()));

        CreateMap<CreationRequestDto, Request>()
            .ForMember(dest => dest.CourseId, opt => opt
                .MapFrom(src => src.CourseId))
            .ForMember(dest => dest.Status, opt => opt
                .MapFrom(src => Enum.Parse<Status>(src.Status)));
    }
}