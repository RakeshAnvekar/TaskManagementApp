using TaskManagementApp.Api.Models.TaskCategory;

namespace TaskManagementApp.Api.Repositories.Interfaces;

public interface ITaskCategoryRepository
{
    public Task<List<TaskCategory>> SelectAllAsync(CancellationToken cancellationToken);

}
