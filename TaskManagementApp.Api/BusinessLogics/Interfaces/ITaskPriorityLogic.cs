
﻿using TaskManagementApp.Api.Models;

namespace TaskManagementApp.Api.BusinessLogics.Interfaces;

public interface ITaskPriorityLogic
{
    public Task<List<TaskPriority?>?> GetTaskPrioritiesAsync(CancellationToken cancellationToken);

}


