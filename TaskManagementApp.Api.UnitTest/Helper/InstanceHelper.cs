
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading; // For CancellationToken
using System.Threading.Tasks; // For Task-related extensions
using TaskManagementApp.Api.Models.TaskItem;
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
    #endregion
   

}
