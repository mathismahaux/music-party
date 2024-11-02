using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class VoteRepository : IVoteRepository
{
    private readonly MusicPartyDbContext _context;

    public VoteRepository(MusicPartyDbContext context)
    {
        _context = context;
    }

    public DbVote Create(int userId, int songId)
    {
        var vote = new DbVote
        {
            UserId = userId,
            SongId = songId
        };
        _context.Votes.Add(vote);
        _context.SaveChanges();
        return vote;
    }
}