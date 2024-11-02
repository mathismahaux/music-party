using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class MusicPartyDbContext : DbContext
{
    public MusicPartyDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbSong> Songs { get; set; }
    public DbSet<DbVote> Votes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Username).HasColumnName("username");
        });
        
        modelBuilder.Entity<DbSong>(entity =>
        {
            entity.ToTable("songs");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id).HasColumnName("id");
            entity.Property(s => s.Title).HasColumnName("title");
            entity.Property(s => s.Genre).HasColumnName("genre");
            entity.Property(s => s.YoutubeUrl).HasColumnName("youtubeUrl");
            entity.Property(s => s.UserId).HasColumnName("userId");
        });
        
        modelBuilder.Entity<DbVote>(entity =>
        {
            entity.ToTable("votes");
            entity.HasKey(v => new {v.UserId, v.SongId});
            entity.Property(v => v.UserId).HasColumnName("userId");
            entity.Property(v => v.SongId).HasColumnName("songId");
        });
    }

}