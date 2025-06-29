using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Errors;
using CourseManagementModule.Application.Repositories;

namespace CourseManagementModule.Application.Services.Test;

public class TestService : ITestService
{
    private readonly ITestRepository _testRepository;
    private readonly ICustomMapper _mapper;

    public TestService(ITestRepository testRepository, ICustomMapper mapper)
    {
        _testRepository = testRepository ?? throw new ArgumentNullException(nameof(testRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Result<TestDto, Error>> GetByIdAsync(Guid id)
    {
        try
        {
            var test = await _testRepository.GetByIdAsync(id);

            var result = _mapper.Map<Domain.Test, TestDto>(test);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<IReadOnlyCollection<TestDto>, Error>> GetByPageIdAsync(Guid id)
    {
        try
        {
            var tests = await _testRepository.GetByPageIdAsync(id);

            var result = tests
                .Select(t => _mapper.Map<Domain.Test, TestDto>(t))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<TestDto, Error>> CreateAsync(CreationTestDto creationTestDto)
    {
        try
        {
            var test = _mapper.Map<CreationTestDto, Domain.Test>(creationTestDto);

            var createdTest = await _testRepository.CreateAsync(test);

            var result = _mapper.Map<Domain.Test, TestDto>(createdTest);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<TestDto, Error>> DeleteByIdAsync(Guid id)
    {
        try
        {
            var deletedTest = await _testRepository.DeleteByIdAsync(id);

            var result = _mapper.Map<Domain.Test, TestDto>(deletedTest);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}