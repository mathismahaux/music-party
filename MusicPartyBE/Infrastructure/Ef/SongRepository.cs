using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class SongRepository : ISongRepository
{
    private readonly MusicPartyDbContext _context;

    public SongRepository(MusicPartyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbSong> FetchAll()
    {
        return _context.Songs.ToList();
    }

    public DbSong? FetchById(int id)
    {
        return _context.Songs.FirstOrDefault(s => s.Id == id);
    }

    public DbSong Create(string title, string genre, string youtubeUrl, int userId)
    {
        var song = new DbSong
        {
            Title = title,
            Genre = genre,
            YoutubeUrl = youtubeUrl,
            UserId = userId
        };
        _context.Songs.Add(song);
        _context.SaveChanges();
        return song;
    }

    public bool Delete(int id)
    {
        var song = _context.Songs.FirstOrDefault(s => s.Id == id);

        if (song == null)
        {
            return false;
        }
        
        _context.Songs.Remove(song);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<DbSong> FetchTop10Songs()
    {
        var top10Songs = _context.Songs
            .Select(song => new 
            {
                Song = song,
                VoteCount = _context.Votes.Count(vote => vote.SongId == song.Id)
            })
            .OrderByDescending(s => s.VoteCount)
            .Take(10)
            .Select(s => s.Song)
            .ToList();

        return top10Songs;
    }
}