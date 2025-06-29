using CourseManagementModule.Domain;

namespace CourseManagementModule.Application.Repositories;

public interface ICourseRepository
{
    Task<IReadOnlyCollection<Course>> GetAsync(int page, int pageSize);
    
    Task<Course> GetByIdAsync(Guid id);

    Task<Course> CreateAsync(Course course);
    
    Task<Course> UpdateAsync(Course course);

    Task<Course> DeleteByIdAsync(Guid id);
}