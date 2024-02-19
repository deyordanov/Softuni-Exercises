namespace SeminarHub.Data.Models;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.Constants.ValidationConstants.Seminar;

public class Seminar
{
    public Seminar()
    {
        this.SeminarsParticipants = new List<SeminarParticipant>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(SeminarTopicMaxLength)]
    public string Topic { get; set; } = string.Empty;

    [Required]
    [StringLength(SeminarLecturerMaxLength)]
    public string Lecturer { get; set; } = string.Empty;

    [Required]
    [StringLength(SeminarDetailsMaxLength)]
    public string Details { get; set; } = string.Empty;

    [Required]
    public string OrganizerId { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(OrganizerId))]
    public IdentityUser Organizer { get; set; } = null!;

    [Required]
    public DateTime DateAndTime { get; set; }

    public int? Duration { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public IList<SeminarParticipant> SeminarsParticipants { get; set; }
}