using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Entities;
using Sample.Application.Requests.Queries;

namespace Sample.WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class Controller : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new Exception($"Service object of type {nameof(IMediator)} not existing.");

        private readonly ILogger<Controller> _logger;

        public Controller(ILogger<Controller> logger) => _logger = logger;

        [HttpGet]
        [Route("allData")]
        public async Task<ActionResult<Log>> GetLog()
        {
            var query = new LogQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("scan")]
        public async Task<ActionResult<Scan>> GetScan()
        {
            var query = new ScanQuery();
            return Ok(await Mediator.Send(query));
        }
    }
}
