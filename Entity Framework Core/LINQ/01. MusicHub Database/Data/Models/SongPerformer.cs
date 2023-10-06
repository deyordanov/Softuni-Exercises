namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class SongPerformer
{
    [ForeignKey(nameof(Song))]
    public int SongId { get; set; }

    public Song Song { get; set; } = null!;

    [ForeignKey(nameof(Performer))]
    public int PerformerId { get; set; }

    public Performer Performer { get; set; } = null!;
}