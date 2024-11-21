using System.Data;
using TaskManagementApp.Api.Models.Priority;

namespace TaskManagementApp.Api.Mappers.Interfaces;

public interface ITaskPriorityMapper
{
    public TaskPriority MapPriority(IDataReader reader);
    public List<TaskPriority>? MapPriorities(IDataReader reader);
}
