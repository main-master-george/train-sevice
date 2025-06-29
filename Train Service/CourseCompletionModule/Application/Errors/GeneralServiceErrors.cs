using Common.Errors;

namespace CourseCompletionModule.Application.Errors;

public class GeneralServiceErrors
{
    private static Error Create(int code, string message)
    {
        return new Error(code, message);
    }

    public static Error UnknownError(string message) =>
        Create(520, message);
}