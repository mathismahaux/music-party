using Application.UseCases.Song.Dtos;
using Application.UseCases.User.Dtos;
using Application.UseCases.Vote;
using AutoMapper;
using Domain;
using Infrastructure.Ef.DbEntities;

namespace Application;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, DtoOutputUser>();
        CreateMap<DbUser, DtoOutputUser>();
        CreateMap<DbUser, User>();
        
        CreateMap<Song, DtoOutputSong>();
        CreateMap<DbSong, DtoOutputSong>();
        CreateMap<DbSong, Song>();
        CreateMap<DtoInputSong, Song>();
        
        CreateMap<Vote, DtoOutputVote>();
        CreateMap<DbVote, DtoOutputVote>();
        CreateMap<DbVote, Vote>();
        CreateMap<DtoInputVote, Vote>();
    }
}