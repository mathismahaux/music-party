using Application;
using Application.UseCases.Song;
using Application.UseCases.User;
using Application.UseCases.Vote;
using Infrastructure.Ef;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddDbContext<MusicPartyDbContext>(cfg => cfg.UseSqlServer(
    builder.Configuration.GetConnectionString("db")
));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();

builder.Services.AddScoped<UseCaseFetchAllUsers>();

builder.Services.AddScoped<UseCaseFetchAllSongs>();
builder.Services.AddScoped<UseCaseCreateSong>();
builder.Services.AddScoped<UseCaseDeleteSong>();
builder.Services.AddScoped<UseCaseFetchTop10Songs>();

builder.Services.AddScoped<UseCaseCreateVote>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:8080")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Dev");

app.UseAuthorization();

app.MapControllers();

app.Run();