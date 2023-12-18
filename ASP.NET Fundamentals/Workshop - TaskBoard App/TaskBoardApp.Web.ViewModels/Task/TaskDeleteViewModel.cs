namespace TaskBoardApp.Web.ViewModels.Task;

public class TaskDeleteViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}