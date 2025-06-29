using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Services.TestPoint;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Services.TestPoint;

namespace Infrastructure.Services.CourseCompletion;

public class TestPointIntegrationService : ITestPointIntegrationService
{
    private readonly ITestPointService _testPointService;
    private readonly ICustomMapper _mapper;


    public TestPointIntegrationService(ITestPointService testPointService, ICustomMapper mapper)
    {
        _testPointService = testPointService ?? throw new ArgumentNullException(nameof(testPointService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<IReadOnlyCollection<TestPointCompletionDto>, Error>> GetByTestIdAsync(Guid id)
    {
        var points = await _testPointService.GetByTestIdAsync(id);

        if (!points.IsSuccess) return points.Error!;

        var result = points.Value!
            .Select(p => _mapper.Map<TestPointDto, TestPointCompletionDto>(p))
            .ToList();

        return result;
    }

    public async Task<Result<Guid, Error>> GetCorrectAnswerIdByTestIdAsync(Guid id)
    {
        var points = await _testPointService.GetByTestIdAsync(id);

        if (!points.IsSuccess) return points.Error!;

        var answer = points.Value!
            .First(p => p.IsValid);

        return answer.Id;
    }
}