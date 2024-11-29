
using Microsoft.Extensions.Logging;
using Moq;
using TaskManagementApp.Api.BusinessLogics;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Repositories.Interfaces;
using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.BusinessLogic;

[TestClass]
public class TaskItemLogicTests
{
    #region Properties
    private Mock<ITaskItemRepository> _taskItemRepositoryMock;
    private DataHelper _dataHelper;
    private ITaskItemLogic _taskItemLogic;
    private Mock<Logger<TaskItemLogic>> _loggerMock;
    #endregion

    #region Test Setup
    [TestInitialize]
    public void Setup()
    {
        _taskItemRepositoryMock = new Mock<ITaskItemRepository>();
        _dataHelper = new DataHelper();
       _taskItemLogic = new TaskItemLogic(_taskItemRepositoryMock.Object);
    }
    #endregion

    #region Methods
    [TestMethod]
    public async Task TaskItemLogic_GetTaskItemAsync_Return_ActiveTaskItems_FromStorageById()
    {
        _taskItemRepositoryMock.Setup(static x => x.SelectAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelper.TaskItems[0]);
        var item =await _taskItemLogic.GetTaskItemAsync(2, CancellationToken.None);
        Assert.IsNotNull(item);
        Assert.IsTrue(item.isActive);
        Assert.IsFalse(item.IsCompleted);
        Assert.IsTrue(item.TaskCategoryId == 1);
        Assert.AreEqual(item.TaskDescription.ToString(), "test desc");
        Assert.AreEqual(item.TaskId, 2);
        Assert.AreEqual(item.TaskPriorityId, 3);
        Assert.AreEqual(item.TaskTitle, "test task title");
        Assert.AreEqual(item.Category, "Category 1");
    }
    #endregion

}
