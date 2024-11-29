using Moq;
using System.ComponentModel.DataAnnotations;
using TaskManagementApp.Api.BusinessLogics;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Repositories.Interfaces;
using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.BusinessLogic;

[TestClass]
public  class TaskCategoryLogicTests
{
    #region Properties
    private Mock<ITaskCategoryRepository> _mockTaskCategoryRepository;
    private ITaskCategoryLogic _taskCategoryLogic;
    private DataHelper _dataHelper;
    #endregion

    #region Test Setup
    [TestInitialize]
    public void Setup()
    {
        _mockTaskCategoryRepository = new Mock<ITaskCategoryRepository>();
        _taskCategoryLogic = new TaskCategoryLogic(_mockTaskCategoryRepository.Object);
        _dataHelper = new DataHelper();

    }
    #endregion

    #region Methods
    [TestMethod]
    public async Task TaskCategoryLogic_GetTaskItemsAsync_SucessfullyReturnsTaskCategories()
    {
        _mockTaskCategoryRepository.Setup(x => x.SelectAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelper.TaskCategories);
        // Act
        var result = await _taskCategoryLogic.GetTaskCategoriesAsync(CancellationToken.None);

        // Assert
        Assert.IsNotNull(result);
        _mockTaskCategoryRepository.Verify(repo => repo.SelectAllAsync(It.IsAny<CancellationToken>()), Times.Once);

    }
    #endregion
}
