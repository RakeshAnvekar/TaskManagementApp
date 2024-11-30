using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.Autentication;

public interface ITokenGenerator
{
    Task<string?> GenerateTokenAsync(UserLogin user, CancellationToken cancellationToken);
}
