using AutoMapper;
using ModerationModule.Application.Dtos.Incoming;
using ModerationModule.Application.Dtos.Outgoing;
using ModerationModule.Domain;

namespace Infrastructure.MappingProfiles.Moderation;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<Response, ResponseDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.RequestId, opt => opt
                .MapFrom(src => src.RequestId))
            .ForMember(dest => dest.Message, opt => opt
                .MapFrom(src => src.Message));

        CreateMap<CreationResponseDto, Response>()
            .ForMember(dest => dest.RequestId, opt => opt
                .MapFrom(src => src.RequestId))
            .ForMember(dest => dest.Message, opt => opt
                .MapFrom(src => src.Message));
    }
}