namespace TaskBoardApp.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static TaskBoardApp.Common.ValidationConstants.Task;

public class Task
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(TaskTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(TaskDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    [ForeignKey(nameof(Board))]
    public int BoardId { get; set; }

    public Board? Board { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public string OwnerId { get; set; } = null!;

    public IdentityUser User { get; set; } = null!;
}