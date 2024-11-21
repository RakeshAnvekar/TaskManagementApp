﻿using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Models.User;
using TaskManagementApp.Api.Repositories.Interfaces;

namespace TaskManagementApp.Api.BusinessLogics;

public sealed class UserLogic : IUserLogic
{
    #region Properties
    private readonly IUserRepository _userRepository;
    #endregion
    public UserLogic(IUserRepository userRepository)
    {
        _userRepository = userRepository;        
    }
    #region Methods

    #endregion
    public async Task<UserTracking> CreateUserAsync(UserRegistraion user, CancellationToken cancellation)
    {
        
       if(user==null) throw  new ArgumentNullException(nameof(user));
       if(user.UserEmailId==null | user.UserEmailId==string.Empty) throw new ArgumentNullException(nameof(user.UserEmailId));
        
        var userTrackking = new UserTracking();

        var userDetails = await _userRepository.GetUserAsync(user?.UserEmailId, cancellation);
        if (userDetails == null)
        {
            await _userRepository.CreateUserAsync(user, cancellation);
            userTrackking.IsUserFound = false;
            userTrackking.UserCreated = true;            
            return userTrackking;
        }
        userTrackking.IsUserFound = true;
        userTrackking.UserCreated = false;
        return userTrackking;
    }
}