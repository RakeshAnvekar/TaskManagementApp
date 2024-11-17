using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.Repositories.Interfaces;
public interface ITaskItemRepository
{
    public Task<List<TaskItem>> SelectAllAsync(CancellationToken cancellationToken);
    public Task<TaskItem?> SelectAsync(int taskId,CancellationToken cancellationToken);
    public Task DeleteAsync(int taskId,CancellationToken cancellationToken);
    public Task CreateAsync(TaskItem taskItem, CancellationToken cancellationToken);
    public Task UpdateAsync(TaskItem taskItem, CancellationToken cancellationToken);
}
