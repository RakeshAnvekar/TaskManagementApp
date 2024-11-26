

using TaskManagementApp.Api.Repositories.Interfaces;
using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.Repository;
[TestClass]
public sealed class TaskCategoryRepositoryTests
{
    #region Properties
    private ITaskCategoryRepository _taskCategoryRepository;
    private DataHelper _dataHelper;
    #endregion

    #region Test Setup 
    [TestInitialize]
    public void Setup()
    {
        _dataHelper = new DataHelper();
        var instanceHelper = new InstanceHelper(_dataHelper);
        _taskCategoryRepository = instanceHelper.GetTaskCategoryRepository();

    }
    [TestMethod]
    public void TaskCategoryRepository_GSelectAllAsync_Gets_AllTaskCategories_FromStorage_Sucessfully()
    {
        var taskCategories = _taskCategoryRepository.SelectAllAsync(CancellationToken.None);
        Assert.IsNotNull(taskCategories);
    }
    #endregion
}
