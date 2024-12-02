using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.BusinessLogics.Interfaces;
using TaskManagementApp.Api.Models.TaskItem;

namespace TaskManagementApp.Api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]    
    public class TaskManagementController : ControllerBase
    {
        #region Properties

        private readonly ILogger<TaskManagementController> _logger;
        private readonly ITaskItemLogic _taskItemLogic;

        #endregion

        #region Constructor
        public TaskManagementController(ILogger<TaskManagementController> logger, ITaskItemLogic taskItemLogic)
        {
            _logger = logger;
            _taskItemLogic = taskItemLogic;
        }

        #endregion

        #region Methods

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> Get() {
            try
            {
                var results =await _taskItemLogic.GetTaskItemsAsync(HttpContext.RequestAborted);
                return Ok(results);

            }
            catch (Exception ex) {
                _logger.LogError($"Class : {nameof(TaskManagementController)} :Error getting TaskItem : Exception : {ex.InnerException}");
                return BadRequest(ex.Message);            
            }                
        }
       
        [HttpGet("GetTaskDetails")]
        public async Task<IActionResult> Get(int taskItemId)
        {
            try
            {
                var result = await _taskItemLogic.GetTaskItemAsync(taskItemId,HttpContext.RequestAborted);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Class : {nameof(TaskManagementController)} :Error getting specific task item details: Exception : {ex.InnerException}");
                return BadRequest(ex.Message);
            }

        }       
        [HttpPut("DeleteTask")]
        public async Task<IActionResult> Delete(int taskItemId)
        {
            try
            {
               await _taskItemLogic.DeleteTaskItemAsync(taskItemId, HttpContext.RequestAborted);
                return Ok(taskItemId);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Class : {nameof(TaskManagementController)} :Error deleteing the Task: Exception : {ex.InnerException}");
                return BadRequest(ex.Message);
            }

        }       
        [HttpPost("CreateNewTaskItem")]
        public async Task<IActionResult> Post([FromBody] TaskItem taskItem)
        {
            try
            {
               await _taskItemLogic.CreateTaskItemAsync(taskItem,HttpContext.RequestAborted);
                return Ok(taskItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Class : {nameof(TaskManagementController)} :Error while Creating New Task Item, TaskItem : {taskItem}, Exception: {ex.InnerException}");
                return BadRequest();  
            }

        }
        [HttpPost("UpdateTaskDetails")]
        public async Task<IActionResult> Put([FromBody] TaskItem taskItem)
        {
            try
            {
                await _taskItemLogic.UpdateTaskItemAsync(taskItem, HttpContext.RequestAborted);
                return Ok(taskItem);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Class : {nameof(TaskManagementController)} :Error while Updating existing Item, TaskItem : {taskItem}, Exception: {ex.InnerException}");
                return BadRequest();
            }
        }

        #endregion
    }
}
