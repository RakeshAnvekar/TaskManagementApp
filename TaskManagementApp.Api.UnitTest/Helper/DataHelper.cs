

using TaskManagementApp.Api.Models.TaskCategory;
using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.UnitTest.Helper;

internal sealed class DataHelper
{
    public List<TaskCategory> TaskCategories { get; set; } = new()
    {
    new TaskCategory{
        TaskCategoryId = 1,
        Category="Category 1"
    },
     new TaskCategory{
        TaskCategoryId = 2,
        Category="Category 2"
    },
      new TaskCategory{
        TaskCategoryId = 3,
        Category="Category 3"
    },
    };
    public List<TaskItem> TaskItems{ get; set; } = new()
    {
    new TaskItem{
        isActive = true,
        IsCompleted = false,
        TaskCategoryId= 1,
        TaskDescription="test desc",
        TaskId= 2,
        TaskPriorityId= 3,
        TaskTitle="test task title",
        Category="Category 1",
        Deadline=DateTime.Now,       
    },
     new TaskItem{
        isActive = true,
        IsCompleted = false,
        TaskCategoryId= 2,
        TaskDescription="test desc",
        TaskId= 3,
        TaskPriorityId= 2,
        TaskTitle="test task title",
        Category="Category 2",
        Deadline=DateTime.Now,
    },
    };

}
