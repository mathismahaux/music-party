using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class UserRepository : IUserRepository
{
    private readonly MusicPartyDbContext _context;

    public UserRepository(MusicPartyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbUser> FetchAll()
    {
        return _context.Users.ToList();
    }
}