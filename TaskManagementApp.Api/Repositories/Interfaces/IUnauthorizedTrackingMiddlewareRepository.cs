namespace TaskManagementApp.Api.Repositories.Interfaces;

public interface IUnauthorizedTrackingMiddlewareRepository
{
    #region Methods
    Task CreateAsync(HttpContext context,CancellationToken cancellationToken);
    #endregion
}
