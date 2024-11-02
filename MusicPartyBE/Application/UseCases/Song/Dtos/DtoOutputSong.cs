namespace Application.UseCases.Song.Dtos;

public class DtoOutputSong
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string YoutubeUrl { get; set; }
    public int UserId { get; set; }
}