using Common.Errors;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Errors;
using CourseCompletionModule.Application.Repositories;
using CourseCompletionModule.Domain;

namespace CourseCompletionModule.Application.Services.Module;

public class ModuleCompletionService : IModuleCompletionService
{
    private readonly IModuleIntegrationService _integrationService;
    private readonly IUserModuleRepository _userModuleRepository;

    public ModuleCompletionService(IModuleIntegrationService integrationService, IUserModuleRepository userModuleRepository)
    {
        _integrationService = integrationService ?? throw new ArgumentNullException(nameof(integrationService));
        _userModuleRepository = userModuleRepository ?? throw new ArgumentNullException(nameof(userModuleRepository));
    }

    public async Task<Result<IReadOnlyCollection<ModuleCompletionDto>, Error>> GetByCourseIdAsync(Guid courseId, Guid userId)
    {
        try
        {
            var modules = await _integrationService.GetByCourseIdAsync(courseId);

            if (!modules.IsSuccess) return modules.Error!;

            var result = modules.Value!.ToList();

            foreach (var module in result)
            {
                var isPurchased = await _userModuleRepository.FindByIdAsync(module.Id, userId);

                module.IsPurchased = isPurchased;
            }

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
        
    }

    public async Task<Result<bool, Error>> AppendAsync(IEnumerable<Guid> moduleIds, Guid userId)
    {
        try
        {
            var userModules = moduleIds
                .Select(m => new UserModule()
                {
                    ModuleId = m, UserId = userId, IsOpen = true
                }).ToList();

            await _userModuleRepository.CreateAsync(userModules);

            return true;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}