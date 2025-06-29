using Common.Errors;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace CourseManagementModule.Application.Services.Course;

public interface ICourseService
{
    Task<Result<IReadOnlyCollection<CourseDto>, Error>> GetAsync(int page, int pageSize, bool isVisible = false);
    
    Task<Result<CourseDto, Error>> GetByIdAsync(Guid id);

    Task<Result<CourseDto, Error>> CreateAsync(CreationCourseDto creationCourseDto);

    Task<Result<CourseDto, Error>> ChangeCourseVisibilityAsync(Guid id, bool isVisible);

    Task<Result<CourseDto, Error>> DeleteByIdAsync(Guid id);
}