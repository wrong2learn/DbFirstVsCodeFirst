using DbFirstVsCodeFirst.DbFirst.Domain;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Infrastructure.DataContext;

public class MusicDbContext : DbContext
{

    public MusicDbContext(
        DbContextOptions<MusicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Artistsband> Artistsbands { get; set; }

    public virtual DbSet<Band> Bands { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasOne(d => d.IdBandNavigation).WithMany(p => p.Albums)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALBUMS_BANDS");
        });

        modelBuilder.Entity<Artistsband>(entity =>
        {
            entity.HasOne(d => d.IdArtistNavigation).WithMany(p => p.Artistsbands)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARTISTSBANDS_ARTISTS");

            entity.HasOne(d => d.IdBandNavigation).WithMany(p => p.Artistsbands)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARTISTSBANDS_BANDS");
        });

        modelBuilder.Entity<Band>(entity =>
        {
            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Bands)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BANDS_GENRE");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasOne(d => d.IdAlbumNavigation).WithMany(p => p.Songs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONGS_ALBUMS");
        });
    }

}
