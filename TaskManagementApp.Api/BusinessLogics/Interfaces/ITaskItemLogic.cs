using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;

public interface ITaskItemLogic
{
    #region Methods
    public Task<List<TaskItem>?> GetTaskItemsAsync(CancellationToken cancellationToken);
    public Task<TaskItem?> GetTaskItemAsync(int taskItemId, CancellationToken cancellationToken);
    public Task DeleteTaskItemAsync(int taskItemId,CancellationToken cancellationToken);
    public Task CreateTaskItemAsync(TaskItem taskItem,CancellationToken cancellationToken);
    public Task UpdateTaskItemAsync(TaskItem taskItem,CancellationToken cancellationToken);
    #endregion
}
