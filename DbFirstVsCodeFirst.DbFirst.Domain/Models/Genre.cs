using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Models;

[Table("GENRES", Schema = "Lookup")]
public partial class Genre
{
    [Key]
    public int Id { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdGenreNavigation")]
    public virtual ICollection<Band> Bands { get; set; } = new List<Band>();
}
