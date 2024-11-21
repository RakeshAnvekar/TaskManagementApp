using TaskManagementApp.Api.Models.Priority;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;

public interface ITaskPriorityLogic
{
    public Task<List<TaskPriority?>?> GetTaskPrioritiesAsync(CancellationToken cancellationToken);
}
