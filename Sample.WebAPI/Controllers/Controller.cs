using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Common.Mapping.DTO;
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

        [HttpGet]
        [Route("filenames")]
        public async Task<ActionResult<IEnumerable<ScanFileWithOnlyFileNameDTO>>> GetScanFilesWithOnlyFileName([FromQuery] bool correct)
        {
            var query = new ScanFilesWithOnlyFileNameQuery()
            {
                Correct = correct
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("errors")]
        public async Task<ActionResult<IEnumerable<ScanFileWithOnlyFileNameAndErrorsDTO>>> GetScanFilesWithOnlyFileNameAndErrors()
        {
            var query = new ScanFilesWithOnlyFileNameAndErrorsQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("errors/count")]
        public async Task<ActionResult<int>> GetErrorCount()
        {
            var query = new ErrorCountQuery();
            return Ok(await Mediator.Send(query));
        }
    }
}
