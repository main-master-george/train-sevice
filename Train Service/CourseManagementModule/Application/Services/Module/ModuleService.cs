using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Errors;
using CourseManagementModule.Application.Repositories;

namespace CourseManagementModule.Application.Services.Module;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly ICustomMapper _mapper;

    public ModuleService(IModuleRepository moduleRepository, ICustomMapper mapper)
    {
        _moduleRepository = moduleRepository ?? throw new ArgumentNullException(nameof(moduleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<ModuleDto, Error>> GetByIdAsync(Guid id)
    {
        try
        {
            var module = await _moduleRepository
                .GetByIdAsync(id);

            var result = _mapper.Map<Domain.Module, ModuleDto>(module);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<IReadOnlyCollection<ModuleDto>, Error>> GetByCourseIdAsync(Guid id)
    {
        try
        {
            var modules = await _moduleRepository
                .GetByCourseIdAsync(id);

            var result = modules
                .Select(m => _mapper.Map<Domain.Module, ModuleDto>(m))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<ModuleDto, Error>> CreateAsync(CreationModuleDto creationModuleDto)
    {
        try
        {
            var module = _mapper.Map<CreationModuleDto, Domain.Module>(creationModuleDto);

            var createdModule = await _moduleRepository.CreateAsync(module);

            var result = _mapper.Map<Domain.Module, ModuleDto>(createdModule);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<ModuleDto, Error>> DeleteByIdAsync(Guid id)
    {
        try
        {
            var module = await _moduleRepository.DeleteByIdAsync(id);

            var result = _mapper.Map<Domain.Module, ModuleDto>(module);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}