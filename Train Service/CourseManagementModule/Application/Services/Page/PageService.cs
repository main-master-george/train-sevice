using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Errors;
using CourseManagementModule.Application.Repositories;

namespace CourseManagementModule.Application.Services.Page;

public class PageService : IPageService
{
    private readonly IPageRepository _pageRepository;
    private readonly ICustomMapper _mapper;

    public PageService(IPageRepository pageRepository, ICustomMapper mapper)
    {
        _pageRepository = pageRepository ?? throw new ArgumentNullException(nameof(pageRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<PageDto, Error>> GetByIdAsync(Guid id)
    {
        try
        {
            var page = await _pageRepository.GetByIdAsync(id);

            var result = _mapper.Map<Domain.Page, PageDto>(page);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<IReadOnlyCollection<PageDto>, Error>> GetByModuleIdAsync(Guid id)
    {
        try
        {
            var pages = await _pageRepository.GetByModuleIdAsync(id);

            var result = pages
                .Select(p => _mapper.Map<Domain.Page, PageDto>(p))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<PageDto, Error>> CreateAsync(CreationPageDto creationPageDto)
    {
        try
        {
            var page = _mapper.Map<CreationPageDto, Domain.Page>(creationPageDto);

            var createdPage = await _pageRepository.CreateAsync(page);

            var result = _mapper.Map<Domain.Page, PageDto>(createdPage);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<PageDto, Error>> DeleteByIdAsync(Guid id)
    {
        try
        {
            var deletedPage = await _pageRepository.DeleteByIdAsync(id);

            var result = _mapper.Map<Domain.Page, PageDto>(deletedPage);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}