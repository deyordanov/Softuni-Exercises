namespace SeminarHub.Data.Models;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SeminarParticipant
{
    [Required]
    public int SeminarId { get; set; }

    [Required]
    [ForeignKey(nameof(SeminarId))]
    public Seminar Seminar { get; set; } = null!;

    [Required]
    public string ParticipantId { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ParticipantId))]
    public IdentityUser Participant { get; set; } = null!;
}