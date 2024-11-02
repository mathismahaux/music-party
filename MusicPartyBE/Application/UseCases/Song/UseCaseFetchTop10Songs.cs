using Application.UseCases.Song.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Song;

public class UseCaseFetchTop10Songs : IUseCaseQuery<IEnumerable<DtoOutputSong>>
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchTop10Songs(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputSong> Execute()
    {
        var songs = _songRepository.FetchTop10Songs();
        return _mapper.Map<IEnumerable<DtoOutputSong>>(songs);
    }
}