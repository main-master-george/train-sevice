using CourseManagementModule.Application.Repositories;
using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CourseManagement;

public class ModuleRepository : IModuleRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ModuleRepository(ApplicationDbContext applicationDbContext) =>
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<Module> GetByIdAsync(Guid id) =>
        await _applicationDbContext
            .Modules
            .FirstAsync(m => m.Id == id);

    public async Task<IReadOnlyCollection<Module>> GetByCourseIdAsync(Guid id) =>
        await _applicationDbContext
            .Modules
            .Where(m => m.CourseId == id)
            .ToListAsync();

    public async Task<Module> CreateAsync(Module module)
    { 
        await _applicationDbContext
            .Modules
            .AddAsync(module);

        await _applicationDbContext
            .SaveChangesAsync();

        return module;
    }

    public async Task<Module> DeleteByIdAsync(Guid id)
    {
        var module = await _applicationDbContext
            .Modules
            .FirstAsync(m => m.Id == id);

        _applicationDbContext
            .Modules
            .Remove(module);

        await _applicationDbContext
            .SaveChangesAsync();

        return module;
    }
}