using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Models.User;

namespace TaskManagementApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Properties
        private readonly IUserLogic _userLogic;
        private readonly ILogger<UserController> _logger;
        #endregion
        #region Constructor
        public UserController(IUserLogic userLogic, ILogger<UserController> logger)
        {
            _userLogic = userLogic;
            
        }
        #endregion
        #region Methods
        [HttpPost]
        public async Task<IActionResult> Post(UserRegistraion userRegistraion)
        {
            try
            {
               var result= await _userLogic.CreateUserAsync(userRegistraion,HttpContext.RequestAborted);
                return Ok(result);
            }
            catch (Exception ex) {
                _logger.LogError($"Error while Creating new User,Exception : {ex.InnerException}");
            return BadRequest(ex.Message);
            }
        #endregion
    }
}
