using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task01.API.DTOs.Responses;
using Task01.Application.Users.Commands.Create;

namespace Task01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Task01BaseController
    {
        public UsersController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand userCommand)
        {
            var result = await mediator.Send(userCommand);
            return Ok(new Response()
            {
                Message = "User Created Succesfully"
            });

        }
    }
}
