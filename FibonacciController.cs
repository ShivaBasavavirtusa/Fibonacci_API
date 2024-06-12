using GnerateFibonacci_Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenerateFibonacci_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FibonacciController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FibonacciController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> GetFibonacci(int number)
        {
            if (number < 0)
            {
                return BadRequest("Number must be non-negative");
            }

            var result = await _mediator.Send(new CalculateFibonacciCommand { Number = number });
            return Ok(result);
        }
    }

}
