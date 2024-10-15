
using DbFirstVsCodeFirst.DbFirst.Domain.DataContext;
using DbFirstVsCodeFirst.DbFirst.Domain.Models;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Repositories;

public interface ISongRepository
{
    Task<ICollection<Song>> GetSongsAsync();
    Task<int> AddSong(Song song);
}

public class SongRepository : ISongRepository
{
    private readonly MusicDbContext _context;

    public SongRepository(
        MusicDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddSong(
        Song song)
    {
        var SongDb = await _context.Songs.AddAsync(song);
        await _context.SaveChangesAsync();

        return SongDb.Entity.Id;
    }

    public Task<ICollection<Song>> GetSongsAsync()
    {
        throw new NotImplementedException();
    }
}

