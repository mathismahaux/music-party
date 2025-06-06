using Application.UseCases.User;
using Application.UseCases.User.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MusicParty.Controllers.User;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly UseCaseFetchAllUsers _useCaseFetchAllUsers;

    public UserController(UseCaseFetchAllUsers useCaseFetchAllUsers)
    {
        _useCaseFetchAllUsers = useCaseFetchAllUsers;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputUser>> FetchAll()
    {
        return Ok(_useCaseFetchAllUsers.Execute());
    }
}