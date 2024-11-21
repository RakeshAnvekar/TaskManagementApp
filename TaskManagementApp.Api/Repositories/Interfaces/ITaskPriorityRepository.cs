using TaskManagementApp.Api.Models.Priority;

namespace TaskManagementApp.Api.Repositories.Interfaces
{
    public interface ITaskPriorityRepository
    {
    /// <summary>
    /// Gets all the Task Priorty dropdown values from data source
    /// </summary>
    /// <returns>
    /// All Active Task Priority items.
    /// </returns>
        public Task<List<TaskPriority>?> SelectAllAsync(CancellationToken cancellationToken);
    }
}
