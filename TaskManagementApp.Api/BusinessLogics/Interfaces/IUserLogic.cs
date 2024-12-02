using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;
public interface IUserLogic
{
    #region Methods
    /// <summary>
    /// Creates new user into system.
    /// </summary>
    /// <param name="user">The User Registraion details.</param>
    /// <param name="cancellation">The Cancellation token.</param>
    /// <returns></returns>
    public Task<UserTracking> CreateUserAsync(UserRegistraion user, CancellationToken cancellation);
    /// <summary>
    /// allow user to login to the system by user id and passord.
    /// </summary>
    /// <param name="userLogin">The UserLogin details.</param>
    /// <param name="cancellation">The Cancellation token.</param>
    /// <returns></returns>
    public Task<UserLogin?> UserLoginAsync(UserLogin userLogin, CancellationToken cancellation);
    
    #endregion
}
