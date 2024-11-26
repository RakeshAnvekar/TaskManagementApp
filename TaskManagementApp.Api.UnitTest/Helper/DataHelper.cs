

using TaskManagementApp.Api.Models;
using TaskManagementApp.Api.Models.TaskCategory;
using TaskManagementApp.Api.Models.TaskItem;
using TaskManagementApp.Api.Models.User;

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

    public List<TaskPriority> taskPriorities { get; set; } = new()
    {
        new TaskPriority{
            TaskPriorityId = 1,
            Priority="High"
        },
         new TaskPriority{
            TaskPriorityId = 2,
            Priority="Low"
        }
    };

    public UserRegistraion userRegistraion { get; set; } = new UserRegistraion
    {
        IsActive = true,
        IsLoggedIn = false,
        UserEmailId="tst@gmail.com",
        UserId=1,
        UserConfirmPassword="123",
        UserPassword="123",
        CreatedDate=DateTime.Now,
        UserName="User1",
        UserTypeId=1
    };

    public List<UserRegistraion> userRegistraions { get; set; } = new()
    {
        new UserRegistraion {
        IsActive = true,
        IsLoggedIn = false,
        UserEmailId="test1@gmail.com",
        UserId=1,
        UserConfirmPassword="123",
        UserPassword="123",
        CreatedDate=DateTime.Now,
        UserName="User1",
        UserTypeId=1
        },
         new UserRegistraion {
        IsActive = true,
        IsLoggedIn = false,
        UserEmailId="test2@gmail.com",
        UserId=1,
        UserConfirmPassword="1234",
        UserPassword="1234",
        CreatedDate=DateTime.Now,
        UserName="User2",
        UserTypeId=2
        },
    };
}
