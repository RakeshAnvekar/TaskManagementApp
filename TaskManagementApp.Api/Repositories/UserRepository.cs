using System.Data;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.User;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.Repositories;

public class UserRepository : IUserRepository
{
    #region Properties
    private readonly IDbExecutor _dbExecutor;
    private readonly IUserMapper _userMapper;
    #endregion

    #region Constructors
    public UserRepository(IDbExecutor dbExecutor, IUserMapper userMapper)
    {
        _dbExecutor = dbExecutor;
        _userMapper = userMapper;
    }
    #endregion

    #region Methods
    public async Task CreateUserAsync(UserRegistraion user, CancellationToken cancellationtoken)
    {
        if(user==null) throw new ArgumentNullException(nameof(user));

        const string sql = @"insert into [User] values(@UserName,@UserEmailId,@UserPassword,@UserConfirmPassword,getdate(),2,1,0)";
        var inputParameters = new Dictionary<string, object?>() {
            { "@UserName",user.UserName},
            { "@UserEmailId",user.UserEmailId},
            { "@UserPassword",user.UserPassword},
            { "@UserConfirmPassword",user.UserConfirmPassword},
        };

        await _dbExecutor.ExecuteAsync(sql, CommandType.Text, cancellationtoken, inputParameters);
      }

    public async Task<UserRegistraion?> GetUserAsync(string userEmailId, CancellationToken cancellation)
    {
        if (string.IsNullOrEmpty(userEmailId)) throw new ArgumentNullException(nameof(userEmailId));
        const string sql = @"SELECT * from [User] where UserEmailId=@UserEmailId";
        var inputParameters = new Dictionary<string, object?>() {
           { "@UserEmailId",userEmailId},           
        };
        return await _dbExecutor.ExecuteQueryAsync(sql, CommandType.Text, cancellation, _userMapper.MapUser, inputParameters);
       }

    public async Task<UserRegistraion?> IsUserExists(string userEmailId, string password, CancellationToken cancellation)
    {
        const string sql = @"SELECT * from [User] where UserEmailId=@UserEmailId and UserPassword=@UserPassword";
        var inputParameters = new Dictionary<string, object?>() {
           { "@UserEmailId",userEmailId},
           { "@UserPassword",password},
        };
        return await _dbExecutor.ExecuteQueryAsync(sql, CommandType.Text, cancellation, _userMapper.MapUser, inputParameters);
       }
    #endregion

}
