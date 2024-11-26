

using TaskManagementApp.Api.Repositories;
using TaskManagementApp.Api.Repositories.Interfaces;
using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.Repository;

[TestClass]
public sealed class TaskPriorityRepositoryTests
{
    #region Properties
    private ITaskPriorityRepository _taskPriorityRepository;
    private  DataHelper _dataHelper;
    #endregion

    #region Setup
    [TestInitialize]
    public void SetUp()
    {
        _dataHelper = new DataHelper();
        var instanceHelper = new InstanceHelper(_dataHelper);
        _taskPriorityRepository = instanceHelper.GetTaskPriorityRepository();
    }
    #endregion


    [TestMethod]
   public async Task TaskPriorityRepository_SelectAsync_Returns_All_TaskPriority_Sucessfully()
    {
      var taskPriorityItems=  await _taskPriorityRepository.SelectAllAsync(CancellationToken.None);
        Assert.IsNotNull(taskPriorityItems);
    }    
}
