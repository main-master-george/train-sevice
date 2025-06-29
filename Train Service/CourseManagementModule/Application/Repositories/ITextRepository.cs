using CourseManagementModule.Domain;

namespace CourseManagementModule.Application.Repositories;

public interface ITextRepository
{
    Task<Text> GetByIdAsync(Guid id);

    Task<IReadOnlyCollection<Text>> GetByPageIdAsync(Guid id);

    Task<Text> CreateAsync(Text text);

    Task<Text> DeleteByIdAsync(Guid id);
}