using Common.Errors;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace CourseManagementModule.Application.Services.TestPoint;

public interface ITestPointService
{
    Task<Result<TestPointDto, Error>> GetByIdAsync(Guid id);

    Task<Result<IReadOnlyCollection<TestPointDto>, Error>> GetByTestIdAsync(Guid id);

    Task<Result<TestPointDto, Error>> CreateAsync(CreationTestPointDto creationTestPointDto);

    Task<Result<TestPointDto, Error>> DeleteByIdAsync(Guid id);
}