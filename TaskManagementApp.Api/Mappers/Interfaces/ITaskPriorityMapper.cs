using System.Data;
using TaskManagementApp.Api.Models;

namespace TaskManagementApp.Api.Mappers.Interfaces;

public interface ITaskPriorityMapper
{
    public TaskPriority MapPriority(IDataReader reader);
    public List<TaskPriority>? MapPriorities(IDataReader reader);
}
