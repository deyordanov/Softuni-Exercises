namespace TaskBoardApp.Data.Models;

using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.ValidationConstants.Board;

public class Board
{
    public Board()
    {
        this.Tasks = new List<Task>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(BoardNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required] public IEnumerable<Task> Tasks { get; set; }
}