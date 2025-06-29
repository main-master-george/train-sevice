using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Errors;
using CourseManagementModule.Application.Repositories;

namespace CourseManagementModule.Application.Services.Course;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICustomMapper _mapper;
    
    public CourseService(ICourseRepository courseRepository, ICustomMapper mapper)
    {
        _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Result<IReadOnlyCollection<CourseDto>, Error>> GetAsync(int page, int pageSize, bool isVisible = false)
    {
        try
        {
            var courses = await _courseRepository
                .GetAsync(page, pageSize);

            if (isVisible) courses = courses.Where(c => c.IsVisibleForUsers).ToList();

            var result = courses
                .Select(c => _mapper.Map<Domain.Course, CourseDto>(c))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<CourseDto, Error>> GetByIdAsync(Guid id)
    {
        try
        {
            var course = await _courseRepository
                .GetByIdAsync(id);

            var result = _mapper.Map<Domain.Course, CourseDto>(course);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<CourseDto, Error>> CreateAsync(CreationCourseDto creationCourseDto)
    {
        try
        {
            var course = _mapper.Map<CreationCourseDto, Domain.Course>(creationCourseDto);

            var createdCourse = await _courseRepository.CreateAsync(course);

            var result = _mapper.Map<Domain.Course, CourseDto>(createdCourse);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<CourseDto, Error>> ChangeCourseVisibilityAsync(Guid id, bool isVisible)
    {
        try
        {
            var course = await _courseRepository.GetByIdAsync(id);

            course.IsVisibleForUsers = isVisible;

            var updatedCourse = await _courseRepository.UpdateAsync(course);

            var result = _mapper.Map<Domain.Course, CourseDto>(updatedCourse);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<CourseDto, Error>> DeleteByIdAsync(Guid id)
    {
        try
        {
            var deletedCourse = await _courseRepository.DeleteByIdAsync(id);

            var result = _mapper.Map<Domain.Course, CourseDto>(deletedCourse);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}