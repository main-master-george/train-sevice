using AutoMapper;
using Common.Mappers;

namespace Infrastructure.Mappers;

public class CustomMapper : ICustomMapper
{
    private readonly IMapper _mapper;

    public CustomMapper(IMapper mapper) =>
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    public TDestination Map<TSource, TDestination>(TSource source) =>
        _mapper.Map<TSource, TDestination>(source);
}