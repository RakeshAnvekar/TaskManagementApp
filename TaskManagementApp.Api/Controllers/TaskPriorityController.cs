﻿using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.BusinessLogics.Interfaces;

namespace TaskManagementApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPriorityController : ControllerBase
    {
        #region Properties

        private readonly ILogger<TaskPriorityController> _logger;
        private readonly ITaskPriorityLogic _taskPriorityLogic;

        #endregion

        #region Constructors
        public TaskPriorityController(ILogger<TaskPriorityController> logger, ITaskPriorityLogic taskPriorityLogic)
        {
            _logger = logger;
            _taskPriorityLogic = taskPriorityLogic;
        }

        #endregion

        #region Methods

        [HttpGet("GetAllTakPriorities")]
        public async Task<IActionResult> Get()
        {
            try
            {
              var items =  await _taskPriorityLogic.GetTaskPrioritiesAsync(HttpContext.RequestAborted);
                return Ok(items);
                
            }
            catch (Exception ex) {
                _logger.LogError($"Class : {nameof(TaskPriorityController)} : Error getting  Task Priority items , Exception: {ex.InnerException}");
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
