using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Errors;
using CourseManagementModule.Application.Repositories;

namespace CourseManagementModule.Application.Services.TestPoint;

public class TestPointService : ITestPointService
{
    private readonly ITestPointRepository _testPointRepository;
    private readonly ICustomMapper _mapper;

    public TestPointService(ITestPointRepository testPointRepository, ICustomMapper mapper)
    {
        _testPointRepository = testPointRepository ?? throw new ArgumentNullException(nameof(testPointRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<TestPointDto, Error>> GetByIdAsync(Guid id)
    {
        try
        {
            var point = await _testPointRepository.GetByIdAsync(id);

            var result = _mapper.Map<Domain.TestPoint, TestPointDto>(point);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<IReadOnlyCollection<TestPointDto>, Error>> GetByTestIdAsync(Guid id)
    {
        try
        {
            var points = await _testPointRepository.GetByTestIdAsync(id);

            var result = points
                .Select(p => _mapper.Map<Domain.TestPoint, TestPointDto>(p))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<TestPointDto, Error>> CreateAsync(CreationTestPointDto creationTestPointDto)
    {
        try
        {
            var point = _mapper.Map<CreationTestPointDto, Domain.TestPoint>(creationTestPointDto);

            var createdPoint = await _testPointRepository
                .CreateAsync(point);

            var result = _mapper.Map<Domain.TestPoint, TestPointDto>(createdPoint);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<TestPointDto, Error>> DeleteByIdAsync(Guid id)
    {
        try
        {
            var deletedPoint = await _testPointRepository
                .DeleteByIdAsync(id);

            var result = _mapper.Map<Domain.TestPoint, TestPointDto>(deletedPoint);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}