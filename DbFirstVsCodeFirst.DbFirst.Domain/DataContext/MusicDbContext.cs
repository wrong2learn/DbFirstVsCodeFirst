using System;
using System.Collections.Generic;
using DbFirstVsCodeFirst.DbFirst.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.DbFirst.Domain.DataContext;

public partial class MusicDbContext : DbContext
{
    public MusicDbContext()
    {
    }

    public MusicDbContext(DbContextOptions<MusicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Artistsband> Artistsbands { get; set; }

    public virtual DbSet<Band> Bands { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DbFirstVsCodeFirstMusicDb;trusted_connection=false;trustServerCertificate=true;User ID=sa;Password=EnterInMySQL1;");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
