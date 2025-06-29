using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseCompletionModule.Application.Dtos.Outgoing;
using CourseCompletionModule.Application.Services.Text;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Services.Text;

namespace Infrastructure.Services.CourseCompletion;

public class TextIntegrationService : ITextIntegrationService
{
    private readonly ITextService _textService;
    private readonly ICustomMapper _mapper;

    public TextIntegrationService(ITextService textService, ICustomMapper mapper)
    {
        _textService = textService ?? throw new ArgumentNullException(nameof(textService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Result<IReadOnlyCollection<TextCompletionDto>, Error>> GetByPageIdAsync(Guid id)
    {
        var texts = await _textService.GetByPageIdAsync(id);

        if (!texts.IsSuccess) return texts.Error!;

        var result = texts.Value!
            .Select(t => _mapper.Map<TextDto, TextCompletionDto>(t))
            .ToList();

        return result;
    }
}