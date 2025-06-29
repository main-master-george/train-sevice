using System.Net;
using System.Net.Mail;
using System.Text;
using Infrastructure.Storages;

namespace Infrastructure.Services;

public class EmailService
{
    private readonly RedisStorage _redisStorage;
    private readonly string _host;
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;
    private readonly string _from;

    public EmailService(RedisStorage redisStorage,
        string host,
        string port,
        string username,
        string password,
        string from)
    {
        _redisStorage = redisStorage ?? throw new ArgumentNullException(nameof(redisStorage));
        _host = host ?? throw new ArgumentNullException(nameof(host));
        _port = int.Parse(port ?? throw new ArgumentNullException(nameof(port)));
        _username = username ?? throw new ArgumentNullException(nameof(username));
        _password = password ?? throw new ArgumentNullException(nameof(password));
        _from = from ?? throw new ArgumentNullException(nameof(from));
    }

    public async Task<bool> IsCodeAccepted(string email, string code) => 
        await _redisStorage.GetWithTimeUpdate(email) == code;

    public async Task SendConfirmationCodeAsync(string email)
    {
        var code = new Random().Next(100000, 999999).ToString();
        
        await _redisStorage.Set(email, code);

        await SendEmailAsync(email, "Код подтверждения", $"Ваш код подтверждения: {code}");
    }
    
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        using var client = new SmtpClient
        {
            Host = _host,
            Port = _port,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_username, _password)
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_from),
            SubjectEncoding = Encoding.UTF8,
            BodyEncoding = Encoding.UTF8,
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        
        mailMessage.To.Add(to);
        
        await client.SendMailAsync(mailMessage);
    }
}