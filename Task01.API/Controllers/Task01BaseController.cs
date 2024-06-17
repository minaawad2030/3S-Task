using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task01BaseController : ControllerBase
    {
        protected readonly IMediator mediator;
        public Task01BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
