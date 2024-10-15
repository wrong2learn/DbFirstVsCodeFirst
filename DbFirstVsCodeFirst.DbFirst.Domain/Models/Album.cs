using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Models;

[Table("ALBUMS")]
public partial class Album
{
    [Key]
    public int Id { get; set; }

    public int IdBand { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [ForeignKey("IdBand")]
    [InverseProperty("Albums")]
    public virtual Band IdBandNavigation { get; set; } = null!;

    [InverseProperty("IdAlbumNavigation")]
    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
