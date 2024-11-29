using Moq;
using TaskManagementApp.Api.BusinessLogics;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Repositories.Interfaces;

using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.BusinessLogic
{
    [TestClass]
    public class TaskPriorityLogicTests
    {
        #region Properties
        private Mock<ITaskPriorityRepository> _mockTaskPriorityRepository;
        private ITaskPriorityLogic _taskPriorityLogic;
        private DataHelper _dataHelper;
        #endregion

        #region Test Setup
        [TestInitialize]
        public void Setup()
        {
            _mockTaskPriorityRepository = new Mock<ITaskPriorityRepository>();
            _taskPriorityLogic = new TaskPriorityLogic(_mockTaskPriorityRepository.Object);
            _dataHelper = new DataHelper();

        }
    #endregion

    #region Methods
    [TestMethod]
        public async Task TaskPriorityLogic_GetTaskPrioritiesAsync_SuccessfullyReturnsTaskPriorities()
        {           

            _mockTaskPriorityRepository
                .Setup(repo => repo.SelectAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(_dataHelper.taskPriorities);

            // Act
            var result = await _taskPriorityLogic.GetTaskPrioritiesAsync(CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);            

            _mockTaskPriorityRepository.Verify(repo => repo.SelectAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
        #endregion
    }
}
