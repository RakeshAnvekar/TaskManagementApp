using System.Data;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.TaskCategory;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.Repositories;

public sealed class TaskCategoryRepository : ITaskCategoryRepository
{
    #region Properties
    private readonly IDbExecutor _dbExecutor;
    private readonly ITaskCategoryMapper _taskCategoryMapper;
    #endregion

    #region Constructor
    public TaskCategoryRepository(IDbExecutor dbExecutor, ITaskCategoryMapper taskCategoryMapper)
    {
        _dbExecutor = dbExecutor;
        _taskCategoryMapper = taskCategoryMapper;
        
    }
    #endregion
    public async Task<List<TaskCategory>> SelectAllAsync(CancellationToken cancellationToken)
    {
        const string sql = @"Select TaskCategoryId,Category from TaskCategory";
        var items= await _dbExecutor.ExecuteQueryAsync(sql,CommandType.Text,cancellationToken,_taskCategoryMapper.MapCategories,null);
        return items;
    }
}
