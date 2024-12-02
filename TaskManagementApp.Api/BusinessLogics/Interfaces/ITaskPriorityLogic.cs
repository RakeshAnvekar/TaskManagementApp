using TaskManagementApp.Api.Models;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;
public interface ITaskPriorityLogic
{
    #region Methods
    /// <summary>
    /// Gets all active task priorities from system.
    /// </summary>
    /// <param name="cancellationToken">The Cancellation token.</param>
    /// <returns>All active task priorities.</returns>
    public Task<List<TaskPriority?>?> GetTaskPrioritiesAsync(CancellationToken cancellationToken);
    
    #endregion
}