using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Services.Course;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Services.Course;

namespace Infrastructure.Services.CourseCompletion;

public class CourseIntegrationService : ICourseIntegrationService
{
    private readonly ICourseService _courseService;
    private readonly ICustomMapper _mapper;

    public CourseIntegrationService(ICourseService courseService, ICustomMapper mapper)
    {
        _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<IReadOnlyCollection<CourseBaseDto>, Error>> GetAsync(int page, int pageSize)
    {
        var courses = await _courseService.GetAsync(page, pageSize);

        if (!courses.IsSuccess) return courses.Error!;

        var result = courses.Value!
            .Select(c => _mapper.Map<CourseDto, CourseBaseDto>(c))
            .ToList();

        return result;
    }

    public async Task<Result<CourseBaseDto, Error>> GetByIdAsync(Guid id)
    {
        var course = await _courseService.GetByIdAsync(id);

        if (!course.IsSuccess) return course.Error!;

        var result = _mapper.Map<CourseDto, CourseBaseDto>(course.Value!);

        return result;
    }
}