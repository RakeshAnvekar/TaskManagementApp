using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;
public interface ITaskItemLogic
{
    #region Methods
    /// <summary>
    /// Gets all active task items from the system.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Active Task Items</returns>
    public Task<List<TaskItem>?> GetTaskItemsAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Gets active task item details from the system by task identificaton.
    /// </summary>
    /// <param name="taskItemId">The task item identification.</param>
    /// <param name="cancellationToken">The Cancellation token.</param>
    /// <returns>Task item details by identification.</returns>
    public Task<TaskItem?> GetTaskItemAsync(int taskItemId, CancellationToken cancellationToken);
    /// <summary>
    /// Deletes task items by identification.
    /// </summary>
    /// <param name="taskItemId">The task item identification.</param>
    /// <param name="cancellationToken">The Cancellation token.</param>
    /// <returns>Deletes task items by identification.</returns>
    public Task DeleteTaskItemAsync(int taskItemId,CancellationToken cancellationToken);
    /// <summary>
    /// Creates new task item in to system.
    /// </summary>
    /// <param name="taskItem">The task item identification.</param>
    /// <param name="cancellationToken">The Cancellation token.</param>
    /// <returns></returns>
    public Task CreateTaskItemAsync(TaskItem taskItem,CancellationToken cancellationToken);
    /// <summary>
    /// Updates Task item details.
    /// </summary>
    /// <param name="taskItem">The task item identification.</param>
    /// <param name="cancellationToken">The Cancellation token.</param>
    /// <returns></returns>
    public Task UpdateTaskItemAsync(TaskItem taskItem,CancellationToken cancellationToken);
   
    #endregion
}
