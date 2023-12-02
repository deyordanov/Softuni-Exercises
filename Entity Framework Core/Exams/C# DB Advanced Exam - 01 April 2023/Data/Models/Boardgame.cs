﻿namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;
using Enums;

public class Boardgame
{
    public Boardgame()
    {
        this.BoardgamesSellers = new HashSet<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public double Rating { get; set; }

    [Required]
    public int YearPublished { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required] 
    public string Mechanics { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Creator))]
    public int CreatorId { get; set; }

    public Creator Creator { get; set; } = null!;

    public ICollection<BoardgameSeller> BoardgamesSellers  { get; set; }
}