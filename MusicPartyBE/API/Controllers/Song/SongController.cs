using Application.UseCases.Song;
using Application.UseCases.Song.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MusicParty.Controllers.Song;

[ApiController]
[Route("api/v1/songs")]
public class SongController : ControllerBase
{
    private readonly UseCaseFetchAllSongs _useCaseFetchAllSongs;
    private readonly UseCaseCreateSong _useCaseCreateSong;
    private readonly UseCaseDeleteSong _useCaseDeleteSong;
    private readonly UseCaseFetchTop10Songs _useCaseFetchTop10Songs;


    public SongController(UseCaseFetchAllSongs useCaseFetchAllSongs, UseCaseCreateSong useCaseCreateSong, UseCaseDeleteSong useCaseDeleteSong, UseCaseFetchTop10Songs useCaseFetchTop10Songs)
    {
        _useCaseFetchAllSongs = useCaseFetchAllSongs;
        _useCaseCreateSong = useCaseCreateSong;
        _useCaseDeleteSong = useCaseDeleteSong;
        _useCaseFetchTop10Songs = useCaseFetchTop10Songs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputSong>> FetchAll()
    {
        return Ok(_useCaseFetchAllSongs.Execute());
    }
    
    [HttpGet("top10")]
    public ActionResult<IEnumerable<DtoOutputSong>> FetchTop10Songs()
    {
        return Ok(_useCaseFetchTop10Songs.Execute());
    }

    [HttpPost]
    public ActionResult<DtoOutputSong> Create(DtoInputSong dto)
    {
        if (!dto.YoutubeUrl.Contains("youtube.com"))
        {
            return BadRequest("Invalid YouTube URL.");
        }
        return Ok(_useCaseCreateSong.Execute(dto));
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return Ok(_useCaseDeleteSong.Execute(id));
    }
}