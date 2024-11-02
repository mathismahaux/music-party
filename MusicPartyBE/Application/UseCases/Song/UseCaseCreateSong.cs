using Application.UseCases.Song.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Song;

public class UseCaseCreateSong : IUseCaseWriter<DtoOutputSong, DtoInputSong>
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateSong(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    public DtoOutputSong Execute(DtoInputSong input)
    {
        var song = _mapper.Map<Domain.Song>(input);
        var dbSong = _songRepository.Create(song.Title, song.Genre, song.YoutubeUrl, song.UserId);
        return _mapper.Map<DtoOutputSong>(dbSong);
    }
}