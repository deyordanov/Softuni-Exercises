namespace TaskBoardApp.Web.ViewModels.Task;

public class TaskDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public string CreatedOn { get; set; } = null!;
    public string Board { get; set; } = null!;
}