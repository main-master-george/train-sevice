using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Services.Module;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Services.Module;

namespace Infrastructure.Services.CourseCompletion;

public class ModuleIntegrationService : IModuleIntegrationService
{
    private readonly IModuleService _moduleService;
    private readonly ICustomMapper _mapper;


    public ModuleIntegrationService(IModuleService moduleService, ICustomMapper mapper)
    {
        _moduleService = moduleService ?? throw new ArgumentNullException(nameof(moduleService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<IReadOnlyCollection<ModuleCompletionDto>, Error>> GetByCourseIdAsync(Guid id)
    {
        var modules = await _moduleService.GetByCourseIdAsync(id);

        if (!modules.IsSuccess) return modules.Error!;

        var result = modules.Value!
            .Select(m => _mapper.Map<ModuleDto, ModuleCompletionDto>(m))
            .ToList();

        return result;
    }
}