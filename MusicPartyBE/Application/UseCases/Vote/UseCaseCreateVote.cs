using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Vote;

public class UseCaseCreateVote : IUseCaseWriter<DtoOutputVote, DtoInputVote>
{
    private readonly IVoteRepository _voteRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateVote(IVoteRepository voteRepository, IMapper mapper)
    {
        _voteRepository = voteRepository;
        _mapper = mapper;
    }

    public DtoOutputVote Execute(DtoInputVote input)
    {
        var vote = _mapper.Map<Domain.Vote>(input);
        var dbVote = _voteRepository.Create(vote.UserId, vote.SongId);
        return _mapper.Map<DtoOutputVote>(dbVote);
    }
}