using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Results;

public class LoginResult
{
    public SignInResult SignInResult { get; set; }
    public string Token { get; set; }
}