using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Models;

[Table("ARTISTSBANDS")]
public partial class Artistsband
{
    [Key]
    public int Id { get; set; }

    public int IdArtist { get; set; }

    public int IdBand { get; set; }

    [ForeignKey("IdArtist")]
    [InverseProperty("Artistsbands")]
    public virtual Artist IdArtistNavigation { get; set; } = null!;

    [ForeignKey("IdBand")]
    [InverseProperty("Artistsbands")]
    public virtual Band IdBandNavigation { get; set; } = null!;
}
