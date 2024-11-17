using System.Data;

namespace TaskManagementApp.Api.DbExecutor.Interface;

public interface IDbExecutor
{
    #region methods
    public Task<T> ExecuteQueryAsync<T>(string sql, CommandType commandType, CancellationToken cancellationToken, Func<IDataReader, T> mapperFuncton, Dictionary<string, object>? inputParams);
    public Task ExecuteAsync(string sql, CommandType commandType, CancellationToken cancellation, Dictionary<string, object>? inputParams);
    #endregion
}
