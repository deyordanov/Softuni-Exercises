namespace SeminarHub.ViewModels.Seminar;

public class SeminarViewModel
{
    public int Id { get; set; }

    public string Topic { get; set; } = string.Empty;

    public string Lecturer { get; set; } = string.Empty;

    public string Details { get; set; } = string.Empty;

    public string OrganizerId { get; set; } = string.Empty;

    public string DateAndTime { get; set; } = string.Empty;

    public int? Duration { get; set; }

    public int CategoryId { get; set; }

    public string Category { get; set; } = string.Empty;

    public string Organizer { get; set; } = string.Empty;
}