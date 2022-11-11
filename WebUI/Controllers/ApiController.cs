using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        protected IMediator Mediator;

        public ApiController(IMediator mediator)
        {
            this.Mediator = mediator;
        }
    }
}
