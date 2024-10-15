using DbFirstVsCodeFirst.CodeFirst.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.CodeFirst.Domain.DataContext;

public class MusicDbContext : DbContext
{
    public MusicDbContext(
        DbContextOptions<MusicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }
    public virtual DbSet<Artistsband> ArtistsBands { get; set; }
    public virtual DbSet<Album> Albums { get; set; }
    public virtual DbSet<Band> Bands { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        // Artist entity
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("ARTISTS");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasColumnName("FIRST_NAME").HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasColumnName("LAST_NAME").HasMaxLength(100).IsRequired();
            entity.Property(e => e.BirthDate).HasColumnName("BIRTH_DATE").IsRequired();
        });

        // Artistsband entity
        modelBuilder.Entity<Artistsband>(entity =>
        {
            entity.ToTable("ARTISTSBANDS");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdArtist).HasColumnName("ID_ARTIST").IsRequired();
            entity.Property(e => e.IdBand).HasColumnName("ID_BAND").IsRequired();

            entity.HasOne(e => e.Artists)
                  .WithMany(a => a.Artistsbands)
                  .HasForeignKey(e => e.IdArtist)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Band)
                  .WithMany(b => b.Artistsbands)
                  .HasForeignKey(e => e.IdBand)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Band entity
        modelBuilder.Entity<Band>(entity =>
        {
            entity.ToTable("BANDS");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdGenre).HasColumnName("ID_GENRE").IsRequired();
            entity.Property(e => e.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();

            entity.HasOne(e => e.Genre)
                  .WithMany(g => g.Bands)
                  .HasForeignKey(e => e.IdGenre)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Genre entity
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("GENRES");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
        });

        // Album entity
        modelBuilder.Entity<Album>(entity =>
        {
            entity.ToTable("ALBUMS");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdBand).HasColumnName("ID_BAND").IsRequired();
            entity.Property(e => e.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();

            entity.HasOne(e => e.Band)
                  .WithMany(b => b.Albums)
                  .HasForeignKey(e => e.IdBand)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Song entity
        modelBuilder.Entity<Song>(entity =>
        {
            entity.ToTable("SONGS");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdAlbum).HasColumnName("ID_ALBUM").IsRequired();
            entity.Property(e => e.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();

            entity.HasOne(e => e.Album)
                  .WithMany(a => a.Songs)
                  .HasForeignKey(e => e.IdAlbum)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
