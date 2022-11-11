using Application.Features.Gatherings.GetGatheringById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatheringsController : ApiController
    {
        public GatheringsController(IMediator mediator)
        : base(mediator)
        {
        }

        [HttpGet("GetGatheringById")]
        public async Task<IActionResult> GetGatheringById([FromQuery] GetGatheringByIdQuery query)
        {
            return this.Ok(await Mediator.Send(query));
        }
    }
}
