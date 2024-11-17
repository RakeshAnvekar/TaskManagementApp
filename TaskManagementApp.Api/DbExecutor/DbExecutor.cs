using System.Data;
using System.Threading;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Models.ConnectionOption;


namespace TaskManagementApp.Api.DbExecutor;
public class DbExecutor : IDbExecutor
{
    #region properties
    private readonly ILogger<DbExecutor> _logger;
    private readonly ConnectionOption _connectionOption;
    #endregion

    #region constructors
    public DbExecutor(ILogger<DbExecutor> logger, IOptions<ConnectionOption> connectionOption)
    {
        _logger = logger;
        _connectionOption=connectionOption.Value;
    }


    #endregion

    #region methods  
    public async Task ExecuteAsync (string sql, CommandType commandType, CancellationToken cancellation, Dictionary<string, object>? inputParams)
    {
        try
        {
            await using var connecton= new SqlConnection(_connectionOption.ConnectionString);
            await using var command = connecton.CreateCommand();
            await connecton.OpenAsync(cancellation);
            command.CommandText = sql;
            command.CommandType = commandType;
            command.CommandTimeout = 30 * 40;
            if (inputParams!=null)
            {
                foreach (var param in inputParams)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
                }

            }
             await command.ExecuteNonQueryAsync(cancellation);
            connecton.Close();

        }
        catch(Exception ex)
        {
            if (cancellation.IsCancellationRequested)
            {
                throw new OperationCanceledException("Operaion is canceller by user ", ex.InnerException, cancellation);
            }
            throw;
        }
        
    }
    public async Task<T> ExecuteQueryAsync<T>(string sql, CommandType commandType, CancellationToken cancellationToken, Func<IDataReader, T> mapperFuncton, Dictionary<string, object>? inputParams)
    {
        try
        {
            await using var connection = new SqlConnection(_connectionOption.ConnectionString);
            await using var command = connection.CreateCommand();
            await connection.OpenAsync(cancellationToken);
            command.CommandText = sql;
            command.CommandType = commandType;
            command.CommandTimeout = 30*40;
            if (inputParams!=null)
            {
                foreach (var param in inputParams) { 
                command.Parameters.AddWithValue(param.Key, param.Value==null? DBNull.Value :param.Value);
                }
            }
            var reader= await command.ExecuteReaderAsync();
            var result=mapperFuncton(reader);
            await connection.CloseAsync();
            return result;
           
        }
        catch (Exception ex) {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("Operaion is canceller by user ",ex.InnerException,cancellationToken);
            }
            throw;
        }
        
    }
    #endregion
}
