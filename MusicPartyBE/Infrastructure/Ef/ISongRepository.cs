using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface ISongRepository
{
    IEnumerable<DbSong> FetchAll();
    DbSong Create(string title, string genre, string youtubeUrl, int userId);
    bool Delete(int id);
    IEnumerable<DbSong> FetchTop10Songs();
}