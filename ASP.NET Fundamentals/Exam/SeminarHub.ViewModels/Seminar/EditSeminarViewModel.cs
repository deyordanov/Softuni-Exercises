using SeminarHub.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.Constants.ValidationConstants.Seminar;
using static SeminarHub.Common.Constants.ValidationMessages.Seminar;

namespace SeminarHub.ViewModels.Seminar;

public class EditSeminarViewModel
{
    public EditSeminarViewModel()
    {
        this.Categories = new List<CategoryViewModel>();
    }

    public int Id { get; set; }

    [Required(ErrorMessage = SeminarTopicRequiredMessage)]
    [StringLength(SeminarTopicMaxLength,
        MinimumLength = SeminarTopicMinLength,
        ErrorMessage = SeminarTopicLengthMessage)]
    public string Topic { get; set; } = string.Empty;

    [Required(ErrorMessage = SeminarLecturerRequiredMessage)]
    [StringLength(SeminarLecturerMaxLength,
        MinimumLength = SeminarLecturerMinLength,
        ErrorMessage = SeminarLecturerLengthMessage)]
    public string Lecturer { get; set; } = string.Empty;

    [Required(ErrorMessage = SeminarDetailsRequiredMessage)]
    [StringLength(SeminarDetailsMaxLength,
        MinimumLength = SeminarDetailsMinLength,
        ErrorMessage = SeminarDetailsLengthMessage)]
    public string Details { get; set; } = string.Empty;

    public string OrganizerId { get; set; } = string.Empty;

    [Required(ErrorMessage = SeminarDateAndTimeRequiredMessage)]
    public string DateAndTime { get; set; } = string.Empty;

    [Range(SeminarDurationMinRange, 
        SeminarDurationMaxRange, 
        ErrorMessage = SeminarDurationRangeMessage)]
    public int? Duration { get; set; }

    [Required(ErrorMessage = SeminarCategoryRequiredMessage)]
    public int CategoryId { get; set; }

    public IList<CategoryViewModel> Categories { get; set; }
}