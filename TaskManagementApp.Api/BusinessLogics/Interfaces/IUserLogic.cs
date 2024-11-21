using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;

public interface IUserLogic
{
    #region Methods
    public Task<UserTracking> CreateUserAsync(UserRegistraion user, CancellationToken cancellation);
    #endregion
}
