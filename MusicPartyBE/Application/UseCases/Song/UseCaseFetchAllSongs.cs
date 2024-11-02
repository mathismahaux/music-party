using Application.UseCases.Song.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Song;

public class UseCaseFetchAllSongs : IUseCaseQuery<IEnumerable<DtoOutputSong>>
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllSongs(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputSong> Execute()
    {
        var songs = _songRepository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputSong>>(songs);
    }
}