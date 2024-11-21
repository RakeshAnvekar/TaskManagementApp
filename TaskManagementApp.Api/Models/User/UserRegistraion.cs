namespace TaskManagementApp.Api.Models.User;

public class UserRegistraion
{
    public int UserId { get; set; }
    public string? UserName {  get; set; }=string.Empty;
    public string? UserEmailId { get; set; } = string.Empty;
    public string? UserPassword { get; set; } = string.Empty;
    public string ?  UserConfirmPassword { get; set; } = string.Empty;
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow; 
    public int UserTypeId { get; set; }
    public bool IsActive { get; set; }
   
}
