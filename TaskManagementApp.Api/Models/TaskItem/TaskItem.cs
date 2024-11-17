namespace TaskManagementApp.Api.Models.TaskItem;

public sealed class TaskItem
{
    public int TaskId { get; set; }
    public string TaskTitle { get; set; } = string.Empty;
    public string TaskDescription { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Priority { get; set; }=string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime Deadline { get; set; } = DateTime.UtcNow;
    public int TaskPriorityId { get; set; }
    public int TaskCategoryId { get; set; }
    public bool isActive { get; set; }
}
