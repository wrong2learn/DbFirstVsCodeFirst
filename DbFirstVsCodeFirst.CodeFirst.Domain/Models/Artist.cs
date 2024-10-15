namespace DbFirstVsCodeFirst.CodeFirst.Domain.Models;

public class Artist
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public virtual ICollection<Artistsband> Artistsbands { get; set; } = new List<Artistsband>();
}

public class Artistsband
{
    public int Id { get; set; }
    public int IdArtist { get; set; }
    public int IdBand { get; set; }

    public virtual Artist Artists { get; set; }
    public virtual Band Band { get; set; }
}

public class Band
{
    public int Id { get; set; }
    public int IdGenre { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; }
    public virtual ICollection<Artistsband> Artistsbands { get; set; }
    public virtual Genre Genre { get; set; } = null!;
}

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Band> Bands { get; set; } = new List<Band>();
}

public class Album
{
    public int Id { get; set; }
    public int IdBand { get; set; }
    public string Name { get; set; }

    public virtual Band Band { get; set; }
    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}

public partial class Song
{
    public int Id { get; set; }
    public int IdAlbum { get; set; }
    public string Name { get; set; }

    public virtual Album Album { get; set; } = null!;
}
