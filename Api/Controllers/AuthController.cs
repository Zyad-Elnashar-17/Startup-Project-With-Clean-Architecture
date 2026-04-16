using Application.Features.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var result = await _mediator.Send(new GetTestStatusQuery());
            return Ok(result);
        }
    }
}
