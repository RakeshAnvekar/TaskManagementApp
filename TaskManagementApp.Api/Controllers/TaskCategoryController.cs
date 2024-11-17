using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.BusinessLogics.Interfaces;

namespace TaskManagementApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : ControllerBase
    {
        #region Properties
        private readonly ILogger<TaskCategoryController> _logger;
        private readonly ITaskCategoryLogic _taskCategoryLogic;
        #endregion
        #region Constructor
        public TaskCategoryController(ILogger<TaskCategoryController> logger, ITaskCategoryLogic taskCategoryLogic)
        {
            _logger = logger;
            _taskCategoryLogic = taskCategoryLogic;

        }
        #endregion

        #region Methods
        [HttpGet("GetAllTaskCategory")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _taskCategoryLogic.GetTaskItemsAsync(HttpContext.RequestAborted);
                return Ok(items);
            }
            catch (Exception ex) {
                _logger.LogError($"Error While Geting AllTaskCategory ,Exception {ex.InnerException}");
            return BadRequest(ex.Message);  
            }

        }
        #endregion


    }
}
