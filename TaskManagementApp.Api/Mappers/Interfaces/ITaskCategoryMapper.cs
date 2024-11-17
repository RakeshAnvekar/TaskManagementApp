using System.Data;
using TaskManagementApp.Api.Models.TaskCategory;

namespace TaskManagementApp.Api.Mappers.Interfaces;

public interface ITaskCategoryMapper
{
    public List<TaskCategory> MapCategories(IDataReader reader);
    public TaskCategory MapCategory(IDataReader reader);
}
