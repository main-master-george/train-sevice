using Common.Errors;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;

namespace CourseManagementModule.Application.Services.Page;

public interface IPageService
{
    Task<Result<PageDto, Error>> GetByIdAsync(Guid id);

    Task<Result<IReadOnlyCollection<PageDto>, Error>> GetByModuleIdAsync(Guid id);
    
    Task<Result<PageDto, Error>> CreateAsync(CreationPageDto creationPageDto);

    Task<Result<PageDto, Error>> DeleteByIdAsync(Guid id);
}