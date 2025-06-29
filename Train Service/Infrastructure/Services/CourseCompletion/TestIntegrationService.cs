using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Services.Test;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Services.Test;

namespace Infrastructure.Services.CourseCompletion;

public class TestIntegrationService : ITestIntegrationService
{
    private readonly ITestService _testService;
    private readonly ICustomMapper _mapper;

    public TestIntegrationService(ITestService testService, ICustomMapper mapper)
    {
        _testService = testService ?? throw new ArgumentNullException(nameof(testService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<IReadOnlyCollection<TestCompletionDto>, Error>> GetByPageIdAsync(Guid id)
    {
        var tests = await _testService.GetByPageIdAsync(id);

        if (!tests.IsSuccess) return tests.Error!;

        var result = tests.Value!
            .Select(t => _mapper.Map<TestDto, TestCompletionDto>(t))
            .ToList();

        return result;
    }
}