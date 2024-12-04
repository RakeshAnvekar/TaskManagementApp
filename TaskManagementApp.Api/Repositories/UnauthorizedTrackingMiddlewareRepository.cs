using System.Data;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Models.TaskItem;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.Repositories;

public sealed class UnauthorizedTrackingMiddlewareRepository : IUnauthorizedTrackingMiddlewareRepository
{
    #region Properties
    private readonly IDbExecutor _dbExecutor;
    #endregion

    #region Constructors
    public UnauthorizedTrackingMiddlewareRepository(IDbExecutor dbExecutor)
    {
        _dbExecutor = dbExecutor;
        
    }
    #endregion

    #region Methods
    public async Task CreateAsync(HttpContext context,CancellationToken cancellationToken)
    {
        if(context==null) throw new ArgumentNullException(nameof(context));
      

        const string sql = @"Insert into UnauthorizedRequestLogs(IPAddress,[Path],Method,[Timestamp])
                            values(@IPAddress,@Path,@Method,@Timestamp)";

        var inputParamerets = new Dictionary<string, object?>() {
            { "@IPAddress",context.Connection.RemoteIpAddress?.ToString() ?? "Unknown" },
            { "@Path", context.Request.Path.ToString()},
            { "@Method", context.Request.Method.ToString()},
            {"@Timestamp",DateTime.UtcNow }
           
        };
        await _dbExecutor.ExecuteAsync(sql, CommandType.Text, cancellationToken, inputParamerets);
    }

    #endregion

}
