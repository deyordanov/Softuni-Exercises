namespace TaskBoardApp.Web.ViewModels.Task;

using System.ComponentModel.DataAnnotations;
using Board;
using static TaskBoardApp.Common.ValidationConstants.Task;

public class TaskFormModel
{
    public TaskFormModel()
    {
        this.Boards = new HashSet<DropdownBoardViewModel>();
    }

    [Required]
    [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength, ErrorMessage = "Title should be at least {2} characters long.")]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(TaskDescriptionMaxLength, MinimumLength = TaskDescriptionMinLength, ErrorMessage = "Description should be at least {2} characters long.")]
    public string Description { get; set; } = null!;

    [Display(Name = "Board")]
    public int BoardId { get; set; }

    public IEnumerable<DropdownBoardViewModel> Boards { get; set; }
}