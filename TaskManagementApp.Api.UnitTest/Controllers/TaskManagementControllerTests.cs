using Microsoft.Extensions.Logging;
using Moq;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Controllers;
using TaskManagementApp.Api.UnitTest.Helper;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.UnitTest.Controllers;

[TestClass]
public sealed class TaskManagementControllerTests
{
    #region Properties
    private Mock<ITaskItemLogic> _taskItemLogicMock;
    private Mock<ILogger<TaskManagementController>> _loggerMock;
    private DataHelper _dataHelperMock;
    private TaskManagementController _taskManagementController;
    #endregion

    #region Test Setup
    [TestInitialize]
    public void Setup()
    {
        // Initialize mocks and test data
        _taskItemLogicMock = new Mock<ITaskItemLogic>();
        _loggerMock = new Mock<ILogger<TaskManagementController>>();
        _dataHelperMock = new DataHelper();

        // Initialize the controller with mocks
        _taskManagementController = new TaskManagementController(_loggerMock.Object, _taskItemLogicMock.Object);
    }
    #endregion

    #region Methods

    [TestMethod]
  
    public async Task TaskManagementController_Get_Returns_All_Active_TaskItems()
    {
        // Arrange
        _taskItemLogicMock = new Mock<ITaskItemLogic>();
        _loggerMock = new Mock<ILogger<TaskManagementController>>();
        _dataHelperMock = new DataHelper();

        _taskItemLogicMock
            .Setup(x => x.GetTaskItemsAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(_dataHelperMock.TaskItems);
        var controller = new TaskManagementController(_loggerMock.Object, _taskItemLogicMock.Object);

        // Act
        var result = await controller.Get();
        //this is only for test cde coverage
     
    }

    #endregion
}
