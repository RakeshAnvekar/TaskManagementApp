using Moq;
using TaskManagementApp.Api.Models.TaskItem;
using TaskManagementApp.Api.Models.User;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.UnitTest.Helper;

internal sealed class InstanceHelper
{
    #region Properties
    private readonly DataHelper _dataHelper;
    #endregion


    #region Constructors
    public InstanceHelper(DataHelper dataHelper)
    {
        _dataHelper=dataHelper;        
    }
    #endregion

    #region Repositories
    private ITaskItemRepository _taskItemRepository;
    private ITaskPriorityRepository _taskPriorityRepository;
    private IUserRepository _userRepository;
    private ITaskCategoryRepository _taskCategoryRepository;
    #endregion

    #region Methods  
    public ITaskItemRepository GetTaskItemRepository() {
        if (_taskItemRepository != null)
        {
            return _taskItemRepository;
        }
        var mock = new Mock<ITaskItemRepository>();

        mock.Setup(x => x.SelectAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
       .ReturnsAsync(_dataHelper.TaskItems[0]);

        mock.Setup(static x => x.SelectAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelper.TaskItems);
        mock.Setup(static x => x.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .Callback((int id, CancellationToken _) =>
            {
                var storedItem = _dataHelper.TaskItems.First(x => x.TaskId == id);
                _dataHelper.TaskItems.Remove(storedItem);
            });

        mock.Setup(static x => x.CreateAsync(It.IsAny<TaskItem>(), It.IsAny<CancellationToken>())).
            Callback((TaskItem item, CancellationToken _) =>
            {
                _dataHelper.TaskItems.Add(item);
            });

        return mock.Object;
    }

    public ITaskPriorityRepository GetTaskPriorityRepository()
    {
        if (_taskPriorityRepository != null)
        {
            return _taskPriorityRepository;
        }

        var mock = new Mock<ITaskPriorityRepository>();
        mock.Setup(static x => x.SelectAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelper.taskPriorities);
        return mock.Object;
    }

    public IUserRepository GetUserRepository()
    {
        if (_userRepository != null)
        {
            return _userRepository;
        }
        var mock= new Mock<IUserRepository>();
        mock.Setup(static x => x.IsUserExists(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelper.userRegistraion);
        mock.Setup(static x => x.GetUserAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelper.userRegistraion);

        mock.Setup(static x => x.CreateUserAsync(It.IsAny<UserRegistraion>(), It.IsAny<CancellationToken>())).
            Callback((UserRegistraion userRegistraion,CancellationToken _) =>
            {
                _dataHelper.userRegistraions.Add(userRegistraion);
            });

        return mock.Object;
    }

    public ITaskCategoryRepository GetTaskCategoryRepository()
    {
        if (_taskCategoryRepository != null)
        {
            return _taskCategoryRepository;
        }
        var mock=new Mock<ITaskCategoryRepository>();
        mock.Setup(static x => x.SelectAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelper.TaskCategories);
        return mock.Object;
    }

    #endregion
   

}
