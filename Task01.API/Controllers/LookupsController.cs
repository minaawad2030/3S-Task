using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task01.Application.Lookups.Cities.Query.GetCitiesByGovernoratesId;
using Task01.Application.Lookups.Governorates.Query.GetAllGovernorates;

namespace Task01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : Task01BaseController
    {
        public LookupsController(IMediator mediator):base(mediator) { }
        
        [HttpGet("Governorates")]
        public async Task<IActionResult> GetGovernates()
        {
            var result=await mediator.Send(new GetAllGovernatesQuery());
            if(result.Count != 0)
                return Ok(result);
            return NoContent();
        }

        [HttpGet("Governorates/{id}/Cities")]
        public async Task<IActionResult> GetCitiesByGovernorateId(int id)
        {
            var cities = await mediator.Send(new GetAllCitiesByGovernoratesIdQuery(id));
            if(cities.Count !=0)
                return Ok(cities);
            return NoContent();
        }
    }
}
