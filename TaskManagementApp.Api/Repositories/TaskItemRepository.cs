using System.Data;
using TaskManagementApp.Api.DbExecutor.Interface;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.TaskItem;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    #region Properties
    private readonly IDbExecutor _dbExecutor;
    private readonly ITaskItemMapper _taskItemMapper;
    #endregion

    #region Constructor
    public TaskItemRepository(IDbExecutor dbExecutor, ITaskItemMapper taskItemMapper)
    {
        _dbExecutor = dbExecutor; 
        _taskItemMapper = taskItemMapper;
    }   
    #endregion

    #region Methods
    public async Task<List<TaskItem>> SelectAllAsync(CancellationToken cancellationToken)
    {
         var items = await _dbExecutor.ExecuteQueryAsync(DbConstants.SP_SelectAllActiveTaskItems, CommandType.Text, cancellationToken,_taskItemMapper.MapTasks, null);
        return items;
    }
    public async Task<TaskItem?> SelectAsync(int taskId, CancellationToken cancellationToken)
    {
        if (taskId < 0 || taskId == 0) {
            throw new ArgumentException(nameof(taskId));
        }
        const string sql = @"Select T.TaskId,
                        T.TaskTitle, 
                        T.TaskDescription, 
                        T.IsCompleted, 
                        T.Deadline,
                        TC.[Category],
                        Tp.[Priority],
                        TP.TaskPriorityId,
                        Tc.TaskCategoryId
                        from Tasks T
                        left outer join TaskCategory TC
                        on T.TaskCategoryId=tc.TaskCategoryId
                        Left outer join TaskPriority TP
                        on T.TaskPriorityId = Tp.TaskPriorityId Where  T.TaskId = @taskId and T.isActive=1 ";

        var inputParameters = new Dictionary<string, object>() {
            {"@taskId" ,taskId}
        };

        var taskItem=await _dbExecutor.ExecuteQueryAsync(sql, CommandType.Text, cancellationToken, _taskItemMapper.MapTask, inputParameters);
        return taskItem;            
    }
    public async Task DeleteAsync(int taskId, CancellationToken cancellationToken)
    {
        if (taskId <= 0)
        {
            throw new ArgumentException("TaskId must be a positive value.", nameof(taskId));
        }
        var inputParametters = new Dictionary<string, object>()
        {
            { "@TaskId",taskId}
        };
        await _dbExecutor.ExecuteAsync(DbConstants.SP_DeleteTaskItemByTaskId, CommandType.StoredProcedure, cancellationToken, inputParametters);        
    }

    public async Task CreateAsync(TaskItem taskItem, CancellationToken cancellationToken)
    {
        if (taskItem == null) throw new ArgumentNullException(nameof(taskItem));
        

        const string sql = @"insert into Tasks
                            (TaskTitle,
                             TaskDescription,
                             IsCompleted,
                             Deadline,
                             TaskCategoryId,
                             TaskPriorityId,
                             isActive) 
			            Values(@TaskTitle,
                               @TaskDescription,
                               @IsCompleted,
                               @Deadline,
                               @TaskCategoryId,
                               @TaskPriorityId,1)";

        var inputParamerets = new Dictionary<string, object>() {
            { "@TaskTitle",taskItem.TaskTitle},
            { "@TaskDescription",taskItem.TaskDescription},
            { "@IsCompleted",taskItem.IsCompleted},
            { "@Deadline",taskItem.Deadline},
            { "@TaskCategoryId",taskItem.TaskCategoryId},
            { "@TaskPriorityId",taskItem.TaskPriorityId}        
        };
      await  _dbExecutor.ExecuteAsync(sql, CommandType.Text, cancellationToken, inputParamerets);       
    }

    public async Task UpdateAsync(TaskItem taskItem, CancellationToken cancellationToken)
    {
        if (taskItem == null) throw new ArgumentNullException(nameof(taskItem));

        const string sql = @"update tasks 
                            set
                            TaskTitle=@TaskTitle,
                            TaskDescription=@TaskDescription,
                            IsCompleted=@IsCompleted,
                            TaskCategoryId=@TaskCategoryId,
                            TaskPriorityId=@TaskPriorityId,
                            isActive=@isActive
                            where TaskId=@TaskId
                            ";

        var inputParamerets = new Dictionary<string, object>() {
            { "@TaskTitle",taskItem.TaskTitle},
            { "@TaskDescription",taskItem.TaskDescription},
            { "@IsCompleted",taskItem.IsCompleted},
            { "@Deadline",taskItem.Deadline},
            { "@TaskCategoryId",taskItem.TaskCategoryId},
            { "@TaskPriorityId",taskItem.TaskPriorityId},
            { "@isActive",taskItem.isActive },
            { "@TaskId", taskItem.TaskId}
        };
        await _dbExecutor.ExecuteAsync(sql, CommandType.Text, cancellationToken, inputParamerets);
    }
    #endregion
}
 