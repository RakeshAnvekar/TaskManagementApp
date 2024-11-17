using System.Data;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.TaskCategory;

namespace TaskManagementApp.Api.Mappers;

public sealed class TaskCategoryMapper : ITaskCategoryMapper
{

    public TaskCategory MapCategory(IDataReader reader)
    {
        if (reader.Read())
        {
            return new TaskCategory()
            {
                TaskCategoryId = reader["TaskCategoryId"] != DBNull.Value ? Convert.ToInt32(reader["TaskCategoryId"]) : 0,
                Category = reader["Category"] != DBNull.Value ? (reader["Category"].ToString()) : "",
            };
        }
        return null;
    }

    public List<TaskCategory> MapCategories(IDataReader reader)
    {
        var taskCategories = new List<TaskCategory>();


        if (reader != null)
        {
            while (reader.Read())
            {
                var taskCategory = MapCategory(reader);
                taskCategories.Add(taskCategory);
            }
        }

        return taskCategories;
    }

 
}
