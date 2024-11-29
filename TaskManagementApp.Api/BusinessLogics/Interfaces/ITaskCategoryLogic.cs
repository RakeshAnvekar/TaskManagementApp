using TaskManagementApp.Api.Models.TaskCategory;
using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;

public interface ITaskCategoryLogic
{
    #region Methods
    public Task<List<TaskCategory>?> GetTaskCategoriesAsync(CancellationToken cancellationToken);
    #endregion
}
