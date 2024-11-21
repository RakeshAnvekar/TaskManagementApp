using System.Data;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models;

namespace TaskManagementApp.Api.Mappers;

public sealed class TaskPriorityMapper: ITaskPriorityMapper
{
    public List<TaskPriority>? MapPriorities(IDataReader reader)
    {
        var priorities = new List<TaskPriority>();
        while (reader != null && reader.Read())
        {
            var priority = MapPriority(reader);
            if (priority != null) priorities.Add(priority);
        }
        return priorities;
    }
    public TaskPriority MapPriority(IDataReader reader)
    {
        if (reader != null && reader.Read())
        {
            return new TaskPriority()
            {

                TaskPriorityId = reader["TaskPriorityId"] != DBNull.Value ? Convert.ToInt32(reader["TaskPriorityId"]) : 0,
                Priority = reader["Priority"] != DBNull.Value ? (reader["Priority"].ToString()) : "",

            };
        }
        return null;

    }
}
