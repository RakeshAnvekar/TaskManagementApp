using System.Data;
using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.Mappers.Interfaces;

public interface ITaskItemMapper
{
    #region Methods
    public TaskItem? MapTask(IDataReader reader);
    public List<TaskItem?> MapTasks(IDataReader reader);
    #endregion
}
