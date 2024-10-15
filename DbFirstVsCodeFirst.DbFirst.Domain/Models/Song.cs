using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Models;

[Table("SONGS")]
public partial class Song
{
    [Key]
    public int Id { get; set; }

    public int IdAlbum { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [ForeignKey("IdAlbum")]
    [InverseProperty("Songs")]
    public virtual Album IdAlbumNavigation { get; set; } = null!;
}
