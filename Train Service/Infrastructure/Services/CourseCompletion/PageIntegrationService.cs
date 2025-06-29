using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Services.Page;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Services.Page;

namespace Infrastructure.Services.CourseCompletion;

public class PageIntegrationService : IPageIntegrationService
{
    private readonly IPageService _pageService;
    private readonly ICustomMapper _mapper;
    
    public PageIntegrationService(IPageService pageService, ICustomMapper mapper)
    {
        _pageService = pageService ?? throw new ArgumentNullException(nameof(pageService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<IReadOnlyCollection<PageCompletionDto>, Error>> GetByModuleIdAsync(Guid id)
    {
        var pages = await _pageService.GetByModuleIdAsync(id);

        if (!pages.IsSuccess) return pages.Error!;

        var result = pages.Value!
            .Select(p => _mapper.Map<PageDto, PageCompletionDto>(p))
            .ToList();

        return result;
    }
}