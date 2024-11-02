using Application.UseCases.Vote;
using Microsoft.AspNetCore.Mvc;

namespace MusicParty.Controllers.Vote;

[ApiController]
[Route("api/v1/votes")]
public class VoteController : ControllerBase
{
    private readonly UseCaseCreateVote _useCaseCreateVote;

    public VoteController(UseCaseCreateVote useCaseCreateVote)
    {
        _useCaseCreateVote = useCaseCreateVote;
    }
    
    [HttpPost]
    public ActionResult<DtoOutputVote> Create(DtoInputVote dto)
    {
        return Ok(_useCaseCreateVote.Execute(dto));
    }
}