using Common.Errors;
using Common.Mappers;
using Common.Results;
using CourseManagementModule.Application.Dtos.Incoming;
using CourseManagementModule.Application.Dtos.Outgoing;
using CourseManagementModule.Application.Errors;
using CourseManagementModule.Application.Repositories;

namespace CourseManagementModule.Application.Services.Text;

public class TextService : ITextService
{
    private readonly ITextRepository _textRepository;
    private readonly ICustomMapper _mapper;

    public TextService(ITextRepository textRepository, ICustomMapper mapper)
    {
        _textRepository = textRepository ?? throw new ArgumentNullException(nameof(textRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<Result<TextDto, Error>> GetByIdAsync(Guid id)
    {
        try
        {
            var text = await _textRepository.GetByIdAsync(id);

            var result = _mapper.Map<Domain.Text, TextDto>(text);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<IReadOnlyCollection<TextDto>, Error>> GetByPageIdAsync(Guid id)
    {
        try
        {
            var texts = await _textRepository.GetByPageIdAsync(id);

            var result = texts
                .Select(t => _mapper.Map<Domain.Text, TextDto>(t))
                .ToList()
                .AsReadOnly();

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<TextDto, Error>> CreateAsync(CreationTextDto creationTextDto)
    {
        try
        {
            var text = _mapper.Map<CreationTextDto, Domain.Text>(creationTextDto);

            var createdText = await _textRepository.CreateAsync(text);

            var result = _mapper.Map<Domain.Text, TextDto>(createdText);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }

    public async Task<Result<TextDto, Error>> DeleteByIdAsync(Guid id)
    {
        try
        {
            var deletedText = await _textRepository.DeleteByIdAsync(id);

            var result = _mapper.Map<Domain.Text, TextDto>(deletedText);

            return result;
        }
        catch (Exception e)
        {
            return GeneralServiceErrors.UnknownError(e.Message);
        }
    }
}