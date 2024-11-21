using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.Repositories.Interfaces;

public interface IUserRepository
{
    #region Methods
    public Task  CreateUserAsync(UserRegistraion user, CancellationToken cancellation);
    public Task<UserRegistraion?> GetUserAsync(string userEmailId,CancellationToken cancellation);
    #endregion
}
