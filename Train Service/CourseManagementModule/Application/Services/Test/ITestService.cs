using Common.Errors;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace CourseManagementModule.Application.Services.Test;

public interface ITestService
{
    Task<Result<TestDto, Error>> GetByIdAsync(Guid id);

    Task<Result<IReadOnlyCollection<TestDto>, Error>> GetByPageIdAsync(Guid id);

    Task<Result<TestDto, Error>> CreateAsync(CreationTestDto creationTestDto);

    Task<Result<TestDto, Error>> DeleteByIdAsync(Guid id);
}