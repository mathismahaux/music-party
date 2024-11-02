using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Vote
{
    public int UserId { get; set; }
    public int SongId { get; set; }
}