using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Errors;
using CourseCompletionModule.Application.Repositories;
using CourseCompletionModule.Domain;

namespace CourseCompletionModule.Application.Services.Course;

public class CourseCompletionService : ICourseCompletionService
{
    private readonly ICourseIntegrationService _integrationService;
    private readonly IUserCourseRepository _userCourseRepository;

    public CourseCompletionService(ICourseIntegrationService integrationService, IUserCourseRepository userCourseRepository)
    {
        _integrationService = integrationService ?? throw new ArgumentNullException(nameof(integrationService));
        _userCourseRepository = userCourseRepository ?? throw new ArgumentNullException(nameof(userCourseRepository));
    }

    public async Task<Result<IReadOnlyCollection<CourseBaseDto>, Error>> GetNotPurchasedAsync(Guid userId, int page, int pageSize)
    {
        try
        {
            var courses = await _integrationService.GetAsync(page, pageSize);

            if (!courses.IsSuccess) return courses.Error!;

            var result = courses.Value!
                .Where(c => !_userCourseRepository.FindByIdAsync(c.Id, userId).Result)
                .ToList();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<IReadOnlyCollection<CourseCompletionDto>, Error>> GetPurchasedAsync(Guid userId, int page, int pageSize)
    {
        try
        {
            var userCourses = await _userCourseRepository.GetPurchasedAsync(userId, page, pageSize);

            var result = new List<CourseCompletionDto>();

            foreach (var userCourse in userCourses)
            {
                var course = await _integrationService.GetByIdAsync(userCourse.CourseId);
                if (!course.IsSuccess) return course.Error!;

                var completion = new CourseCompletionDto()
                {
                    UserId = userCourse.UserId,
                    CourseId = userCourse.CourseId,
                    Name = course.Value!.Name,
                    Description = course.Value!.Description,
                    StartDateTime = userCourse.StartDateTime
                };
                
                result.Add(completion);
            }

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<bool, Error>> AppendAsync(Guid courseId, Guid userId)
    {
        try
        {
            var userCourse = new UserCourse()
            {
                CourseId = courseId,
                UserId = userId,
                StartDateTime = DateTime.UtcNow
            };

            await _userCourseRepository.CreateAsync(userCourse);

            return true;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}