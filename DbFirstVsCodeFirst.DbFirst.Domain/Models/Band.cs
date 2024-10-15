using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Models;

[Table("BANDS")]
public partial class Band
{
    [Key]
    public int Id { get; set; }

    public int IdGenre { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdBandNavigation")]
    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    [InverseProperty("IdBandNavigation")]
    public virtual ICollection<Artistsband> Artistsbands { get; set; } = new List<Artistsband>();

    [ForeignKey("IdGenre")]
    [InverseProperty("Bands")]
    public virtual Genre IdGenreNavigation { get; set; } = null!;
}
