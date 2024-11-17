using System.Data;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.Mappers;

public sealed class TaskItemMapper : ITaskItemMapper
{
    #region Methods
    public TaskItem MapTask(IDataReader reader)
    {
        if (reader.Read())
        {
            return new TaskItem()
            {
                TaskId = reader["TaskId"] != DBNull.Value ? Convert.ToInt32(reader["TaskId"]) : 0,
                TaskTitle = reader["TaskTitle"] != DBNull.Value ? reader["TaskTitle"].ToString() : "Not Provided",
                TaskDescription = reader["TaskDescription"] != DBNull.Value ? reader["TaskDescription"].ToString() : "Not Provided",
                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : "Not Provided",
                Priority = reader["Priority"] != DBNull.Value ? reader["Priority"].ToString() : "Not Provided",
                IsCompleted = reader["IsCompleted"] != DBNull.Value ? Convert.ToBoolean(reader["IsCompleted"]) : false,
                Deadline = reader["Deadline"] != DBNull.Value ? Convert.ToDateTime(reader["Deadline"]) : DateTime.UtcNow,
                TaskCategoryId = reader["TaskCategoryId"] != DBNull.Value ? Convert.ToInt32(reader["TaskCategoryId"]) : 0,
                TaskPriorityId = reader["TaskPriorityId"] != DBNull.Value ? Convert.ToInt32(reader["TaskPriorityId"]) : 0,
            };
        }

         return null;
    }

    public List<TaskItem?> MapTasks(IDataReader reader)
    {
        var taskItems = new List<TaskItem?>();

        if (reader != null)
        {
            while (reader.Read())
            {
                var task = MapTask(reader);
                if (task != null)  
                {
                    taskItems.Add(task);
                }
            }
        }

        return taskItems;
    }


    #endregion
}
