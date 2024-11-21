using Microsoft.AspNetCore.Http.Features;
using System;
using System.Data;
using System.Data.SqlTypes;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.Priority;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.Repositories;

public sealed class TaskPriorityRepository:ITaskPriorityRepository
{
    #region Properties
    private readonly IDbExecutor _executor;
    private readonly ITaskPriorityMapper _taskPriorityMapper;
    #endregion
    #region Constructor
    public TaskPriorityRepository(IDbExecutor executor, ITaskPriorityMapper taskPriorityMapper)
    {
        _executor = executor;
        _taskPriorityMapper = taskPriorityMapper;
    }

    #endregion

    #region Methods
    public async Task<List<TaskPriority>?> SelectAllAsync(CancellationToken cancellationToken)
    {
        const string sql = @"SELECT TaskPriorityId,[Priority] from TaskPriority";
      var items= await _executor.ExecuteQueryAsync(sql, CommandType.Text, cancellationToken, _taskPriorityMapper.MapPriorities, null);
        return items;        
    }
    #endregion
}
