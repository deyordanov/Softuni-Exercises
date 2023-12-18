namespace TaskBoardApp.Web.ViewModels.Task;

public class AllTasksViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Owner { get; set; } = null!;
}