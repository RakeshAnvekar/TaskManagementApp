using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Models.Priority;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.BusinessLogics;

public class TaskPriorityLogic : ITaskPriorityLogic
{
    #region Properties
    private readonly ITaskPriorityRepository _taskPriorityRepository;
    #endregion

    #region Constructor
    public TaskPriorityLogic(ITaskPriorityRepository taskPriorityRepository)
    {
        _taskPriorityRepository = taskPriorityRepository;  
    }
    #endregion

    #region Mehods
    #endregion
    public async Task<List<TaskPriority?>?> GetTaskPrioritiesAsync(CancellationToken cancellationToken)
    {
      return await _taskPriorityRepository.SelectAllAsync(cancellationToken);       
    }
}
