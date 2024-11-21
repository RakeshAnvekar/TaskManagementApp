namespace TaskManagementApp.Api.Models.User;

public class UserTracking:UserRegistraion
{
    public bool IsUserFound { get; set; }=false;
    public bool UserCreated { get; set; } = false;
}
