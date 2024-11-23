namespace TaskManagementApp.Api.Models.User;

public sealed class UserLogin
{
    public string? UserEmailId { get; set; }
    public string? UserPassword { get; set; }
    public bool? IsLoggedIn { get; set; }
}
