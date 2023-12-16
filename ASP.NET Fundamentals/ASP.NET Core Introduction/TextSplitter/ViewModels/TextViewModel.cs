namespace TextSplitter.ViewModels;

using System.ComponentModel.DataAnnotations;

public class TextViewModel
{
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string Text { get; set; } = null!;

    public string SplitText { get; set; } = null!;
}