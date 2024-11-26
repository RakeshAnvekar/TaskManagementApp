
using Microsoft.Identity.Client;
using TaskManagementApp.Api.Repositories.Interfaces;
using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.Repository;

[TestClass]
public sealed class UserRepositoryTests
{
    #region Properties
    private IUserRepository _userRepository;
    private DataHelper _dataHelper;
    #endregion

    #region Test Setup
    [TestInitialize]
    public void Setup()
    {
        _dataHelper = new DataHelper();
        var instanceHelper = new InstanceHelper(_dataHelper);
        _userRepository= instanceHelper.GetUserRepository();
    }
    #endregion

    #region Methods
    [TestMethod]
    public void UserRepository_IsUserExists_Validates_IsUserExists_InSystem_sucessfully()
    {
        var user = _userRepository.IsUserExists(_dataHelper.userRegistraion.UserEmailId,_dataHelper.userRegistraion.UserPassword,CancellationToken.None);
        Assert.IsNotNull(user);
    }

    [TestMethod]
    public void UserRepository_GetUserAsync_Returns_UserFromSystem_sucessfully()
    {
        var user = _userRepository.GetUserAsync(_dataHelper.userRegistraion.UserEmailId, CancellationToken.None);
        Assert.IsNotNull(user);
    }

    [TestMethod]
    public void UserRepository_CreateUserAsync_CreatesNew_UserInSystem_sucessfully()
    {
        var user = _userRepository.CreateUserAsync(_dataHelper.userRegistraion, CancellationToken.None);
        Assert.AreEqual(_dataHelper.userRegistraions.Count, 3);
    }
    #endregion
}
