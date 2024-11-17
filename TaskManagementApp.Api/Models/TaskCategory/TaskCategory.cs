namespace TaskManagementApp.Api.Models.TaskCategory;

public sealed class TaskCategory
{
    #region Properties
    public int TaskCategoryId { get; set; }
    public string Category { get; set; }=string.Empty;
    #endregion
}
