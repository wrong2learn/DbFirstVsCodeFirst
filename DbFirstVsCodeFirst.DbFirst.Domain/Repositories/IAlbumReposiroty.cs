using DbFirstVsCodeFirst.DbFirst.Domain.Models;

namespace DbFirstVsCodeFirst.DbFirst.Domain.Repositories;

public interface IAlbumReposiroty
{    
    Task<ICollection<Album>> GetAlbumsAsync();
    Task<int> AddAlbum(Album album);    
}
