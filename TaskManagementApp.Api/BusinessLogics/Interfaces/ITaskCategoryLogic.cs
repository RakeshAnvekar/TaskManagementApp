using TaskManagementApp.Api.Models.TaskCategory;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;

public interface ITaskCategoryLogic
{
    #region Methods

    /// <summary>
    /// Gets All the active Task Categories from the system.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns> All the active Task Categories from the system.</returns>
    public Task<List<TaskCategory>?> GetTaskCategoriesAsync(CancellationToken cancellationToken);
    
    #endregion
}
