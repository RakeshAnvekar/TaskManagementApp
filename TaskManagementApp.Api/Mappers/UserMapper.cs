using System.Data;
using TaskManagementApp.Api.Mappers.Interfaces;
using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.Mappers;

public class UserMapper : IUserMapper
{
    public UserRegistraion? MapUser(IDataReader dataReader)
    {
      if(!dataReader.Read()) return null;
        return new UserRegistraion
        {
            UserId= dataReader["UserId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserId"]) : 0,
            UserName = dataReader["UserName"] != DBNull.Value ? (dataReader["UserName"].ToString()) : "N/A",
            UserEmailId = dataReader["UserEmailId"] != DBNull.Value ? (dataReader["UserEmailId"].ToString()) : "N/A",
            UserPassword = dataReader["UserPassword"] != DBNull.Value ? (dataReader["UserPassword"].ToString()) : "N/A",
            UserConfirmPassword = dataReader["UserConfirmPassword"] != DBNull.Value ? (dataReader["UserConfirmPassword"].ToString()) : "N/A",
            UserTypeId = dataReader["UserTypeId"] != DBNull.Value ? Convert.ToInt32(dataReader["UserTypeId"]) : 0 ,
            IsActive = dataReader["IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["IsActive"]) : false ,
            CreatedDate = dataReader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(dataReader["IsActive"]) : DateTime.UtcNow,
        };
    }

    public List<UserRegistraion> MapUsers(IDataReader dataReader)
    {
        var users = new List<UserRegistraion>();
        while (dataReader != null && dataReader.Read())
        {
            var user = MapUser(dataReader);
            if(user!=null) users.Add(user);
        }
        return users;
    }
}
