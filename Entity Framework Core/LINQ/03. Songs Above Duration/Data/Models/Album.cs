namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Album
{
    public Album()
    {
        this.Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(ValidationConstants.AlbumNameMaxLength)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime ReleaseDate { get; set; }

    [NotMapped]
    public decimal Price
        => this.Songs.Sum(song => song.Price);

    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }

    public Producer? Producer { get; set; }

    public ICollection<Song> Songs { get; set; }
}