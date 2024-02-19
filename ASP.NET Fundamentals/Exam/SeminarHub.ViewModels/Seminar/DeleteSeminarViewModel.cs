namespace SeminarHub.ViewModels.Seminar;

public class DeleteSeminarViewModel
{
    public int Id { get; set; }

    public string Topic { get; set; } = string.Empty;

    public string DateAndTime { get; set; } = string.Empty;

    public string OrganizerId { get; set; } = string.Empty;
}