using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Models.TaskCategory;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.BusinessLogics;

public sealed class TaskCategoryLogic : ITaskCategoryLogic
{
    #region Properties
    private readonly ITaskCategoryRepository _taskCategoryRepository;
    #endregion

    #region Constructor
    public TaskCategoryLogic(ITaskCategoryRepository taskCategoryRepository)
    {
        _taskCategoryRepository = taskCategoryRepository;
    }
    #endregion

    #region Methods
    public async Task<List<TaskCategory>?> GetTaskItemsAsync(CancellationToken cancellationToken)
    {
     return await _taskCategoryRepository.SelectAllAsync(cancellationToken);        
    }
    #endregion
}
