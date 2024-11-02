using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IVoteRepository
{
    DbVote Create(int userId, int songId);
}