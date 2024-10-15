using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Models;

[Table("ARTISTS")]
public partial class Artist
{
    [Key]
    public int Id { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(1000)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    [InverseProperty("IdArtistNavigation")]
    public virtual ICollection<Artistsband> Artistsbands { get; set; } = new List<Artistsband>();
}
