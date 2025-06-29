using Common.Errors;

namespace UserManagementModule.Application.Errors;

public static class UserServiceErrors
{
    private static Error Create(int code, string message)
    {
        return new Error(code, message);
    }

    public static Error NotFoundError(string message = "User not found in database.") =>
        Create(404, message);
}