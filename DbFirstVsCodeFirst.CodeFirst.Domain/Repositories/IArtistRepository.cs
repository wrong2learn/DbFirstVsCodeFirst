using DbFirstVsCodeFirst.CodeFirst.Domain.DataContext;
using DbFirstVsCodeFirst.CodeFirst.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstVsCodeFirst.CodeFirst.Domain.Repositories;

public interface IArtistRepository
{
    Task<ICollection<Artist>> GetArtistsAsync();
    Task<int> AddArtist(Artist artist);
}

public class ArtistRepository : IArtistRepository
{
    private readonly MusicDbContext _context;

    public ArtistRepository(
        MusicDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddArtist(
        Artist artist)
    {
        var artistDb = await _context.Artists.AddAsync(artist);
        await _context.SaveChangesAsync();

        return artistDb.Entity.Id;

    }

    public async Task<ICollection<Artist>> GetArtistsAsync()
    {
        return await _context.Artists.ToListAsync();
    }
}