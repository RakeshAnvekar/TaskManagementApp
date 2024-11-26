using TaskManagementApp.Api.Models.TaskItem;
using TaskManagementApp.Api.Repositories.Interfaces;
using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.Repository;

[TestClass]
public sealed class TaskItemRepositoryTests
{
    private ITaskItemRepository _taskItemRepository=null;
    private DataHelper _dataHelper;

    [TestInitialize]
    public void Setup()
    {
        _dataHelper = new DataHelper();
        var instanceHelper = new InstanceHelper(_dataHelper);
        _taskItemRepository = instanceHelper.GetTaskItemRepository();
    }

    [TestMethod]
    public void TaskItemRepository_SelectAllAsync_Returns_AllTaskItems_Sucessfully()
    {
        var items = _taskItemRepository.SelectAllAsync(CancellationToken.None);
        Assert.IsNotNull(items);
    }

    [TestMethod]
    public void TaskItemRepository_SelectAsync_Returns_TaskItems_Sucessfully_ById()
    {
       var item = _taskItemRepository.SelectAsync(_dataHelper.TaskItems[0].TaskId, CancellationToken.None);
        Assert.IsNotNull(item);
    }

    [TestMethod]
    public void TaskItemRepository_DeleteAsync_Deletes_TaskItem_Sucessfully_ById()
    {
       _taskItemRepository.DeleteAsync(_dataHelper.TaskItems[0].TaskId, CancellationToken.None);
        Assert.AreEqual(_dataHelper.TaskItems.Count, 1);
    }

    [TestMethod]
    public void TaskItemRepository_CreateAsync_Adds_TaskItem_Sucessfully()
    {
      
        var taskItem = new TaskItem
        {
            isActive = true,
            IsCompleted = false,
            TaskCategoryId = 4,
            TaskDescription = "test desc",           
            TaskPriorityId = 3,
            TaskTitle = "test task title",
            Category = "Category 1",
            Deadline = DateTime.Now,
        };

      var taskItemAfterCreate=  _taskItemRepository.CreateAsync(taskItem, CancellationToken.None);
        Assert.IsNotNull(taskItemAfterCreate);
    }
}