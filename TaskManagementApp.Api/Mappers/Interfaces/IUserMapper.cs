using System.Data;
using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.Mappers.Interfaces;

public interface IUserMapper
{
    #region Properries
    public List<UserRegistraion> MapUsers(IDataReader dataReader);
    public UserRegistraion? MapUser(IDataReader dataReader);
    #endregion
}
