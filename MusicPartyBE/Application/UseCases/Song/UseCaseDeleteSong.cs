using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Song;

public class UseCaseDeleteSong : IUseCaseParametrizedQuery<bool, int>
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public UseCaseDeleteSong(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    public bool Execute(int id)
    {
        return _songRepository.Delete(id);
    }
}