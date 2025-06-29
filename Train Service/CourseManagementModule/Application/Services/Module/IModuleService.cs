using Common.Errors;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace CourseManagementModule.Application.Services.Module;

public interface IModuleService
{
    Task<Result<ModuleDto, Error>> GetByIdAsync(Guid id);

    Task<Result<IReadOnlyCollection<ModuleDto>, Error>> GetByCourseIdAsync(Guid id);

    Task<Result<ModuleDto, Error>> CreateAsync(CreationModuleDto creationModuleDto);

    Task<Result<ModuleDto, Error>> DeleteByIdAsync(Guid id);
}