namespace UserManagementModule.Application.Dtos.Outgoing;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}