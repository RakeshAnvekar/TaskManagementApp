using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Models.TaskItem;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.BusinessLogics;

public sealed class TaskItemLogic : ITaskItemLogic
{
    #region Properties
    private readonly ILogger<TaskItemLogic> _logger;
    private readonly ITaskItemRepository _taskItemRepository;
    #endregion

    #region Constructors
    public TaskItemLogic(ILogger<TaskItemLogic> logger, ITaskItemRepository taskItemRepository)
    {
        _logger = logger;
        _taskItemRepository = taskItemRepository;        
    }

    
    #endregion

    #region Methods
    public async Task<List<TaskItem>?> GetTaskItemsAsync(CancellationToken cancellationToken)
    {
       return await _taskItemRepository.SelectAllAsync(cancellationToken);       
    }
    public async Task DeleteTaskItemAsync(int taskItemId, CancellationToken cancellationToken)
    {
       await _taskItemRepository.DeleteAsync(taskItemId, cancellationToken);
    }

    public async Task<TaskItem?> GetTaskItemAsync(int taskItemId, CancellationToken cancellationToken)
    {
        return await _taskItemRepository.SelectAsync(taskItemId, cancellationToken);
    }

    public async Task CreateTaskItemAsync(TaskItem taskItem, CancellationToken cancellationToken)
    {
        await _taskItemRepository.CreateAsync(taskItem, cancellationToken);        
    }

    public async Task UpdateTaskItemAsync(TaskItem taskItem, CancellationToken cancellationToken)
    {
        await _taskItemRepository.UpdateAsync(taskItem, cancellationToken);
    }
    #endregion
}
