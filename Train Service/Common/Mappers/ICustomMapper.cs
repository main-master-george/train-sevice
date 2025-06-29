namespace Common.Mappers;

public interface ICustomMapper
{
    TDestination Map<TSource, TDestination>(TSource source);
}