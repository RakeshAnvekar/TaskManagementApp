
using Moq;
using TaskManagementApp.Api.BusinessLogics;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Models.User;
using TaskManagementApp.Api.Repositories.Interfaces;
using TaskManagementApp.Api.UnitTest.Helper;

namespace TaskManagementApp.Api.UnitTest.BusinessLogic;

[TestClass]
public sealed class UserLogicTests
{
    #region Properties
    private  Mock<IUserRepository> _userRepositoryMock;
    private  DataHelper _dataHelperMock;
    private  IUserLogic _userLogic;
    #endregion

    #region Test Setup
    [TestInitialize]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userLogic = new UserLogic(_userRepositoryMock.Object);
        _dataHelperMock = new DataHelper();
    }
    #endregion

    #region Methods
    [TestMethod]
    public async Task UserLogic_UserLoginAsync_ReturnsUser_IfExists()
    {
        _userRepositoryMock.Setup(static x => x.IsUserExists(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(_dataHelperMock.userRegistraion);
        var result= await _userLogic.UserLoginAsync(_dataHelperMock.userLogins[0], CancellationToken.None);
        Assert.IsNotNull(result);
    }
    [TestMethod]
    public void  UserLogic_CreateUserAsync_CeatesNewUserIntoSystem()
    {
        var initialUserCount = _dataHelperMock.userRegistraions.Count;
        _userRepositoryMock.Setup(static x => x.CreateUserAsync(It.IsAny<UserRegistraion>(), It.IsAny<CancellationToken>())).
            Callback((UserRegistraion user,CancellationToken _) =>
        {
            _dataHelperMock.userRegistraions.Add(user);
            var result = _userLogic.CreateUserAsync(user, CancellationToken.None);
            Assert.IsNotNull(result);
            Assert.AreEqual(initialUserCount + 1, _dataHelperMock.userRegistraions.Count);
        });       
    }
    #endregion
}
