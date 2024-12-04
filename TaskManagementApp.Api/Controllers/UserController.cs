using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.Autentication;
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
        private readonly ITokenGenerator _tokenGenerator;

        #endregion

        #region Constructor
        public UserController(IUserLogic userLogic, ILogger<UserController> logger, ITokenGenerator tokenGenerator)
        {
            _userLogic = userLogic;
            _logger = logger;
            _tokenGenerator = tokenGenerator;

        }
        #endregion

        #region Methods

        [HttpPost("Register")]
        public async Task<IActionResult> Post(UserRegistraion userRegistraion)
        {
           
            try
            {
                var result = await _userLogic.CreateUserAsync(userRegistraion, HttpContext.RequestAborted);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Class : {nameof(UserController)} :Error while Creating new User,Exception : {ex.InnerException}");
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Get(UserLogin userLogin)
        {
            if (userLogin == null) throw new ArgumentNullException(nameof(userLogin));
            if (userLogin.UserEmailId == null) throw new ArgumentNullException(nameof(userLogin.UserEmailId));
            if (userLogin.UserPassword == null) throw new ArgumentNullException(nameof(userLogin.UserEmailId));

            try
            {
                var user = await _userLogic.UserLoginAsync(userLogin, HttpContext.RequestAborted);
                if (user == null) return Unauthorized();
                var tokenValue = await _tokenGenerator.GenerateTokenAsync(user, HttpContext.RequestAborted);
                if (string.IsNullOrEmpty(tokenValue))
                {
                    return NotFound($"Class : {nameof(UserController)} :Not able to create token for user :{userLogin.UserEmailId}");
                }
                return Ok(new { Token = tokenValue,User=user });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Class : {nameof(UserController)} :Error while using login,Exception : {ex.InnerException}");
                 return Unauthorized();
            }

        }

        #endregion
    }
}
