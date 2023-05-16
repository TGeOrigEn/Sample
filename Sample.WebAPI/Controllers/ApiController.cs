using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Common.Mapping.DTO;
using Sample.Application.Entities;
using Sample.Application.Requests.Commands;
using Sample.Application.Requests.Queries;
using System.Reflection;

namespace Sample.WebAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new Exception($"Service object of type {nameof(IMediator)} not existing.");

        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger) => _logger = logger;

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

        [HttpGet]
        [Route("errors/{index}")]
        public async Task<ActionResult<ScanFileWithOnlyFileNameAndErrorsDTO?>> GetScanFileWithOnlyFileNameAndErrorsByIndex(int index)
        {
            var query = new ScanFileWithOnlyFileNameAndErrorsByIndexQuery() { Index = index };
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("query/check")]
        public async Task<ActionResult<CheckResultDTO>> GetCheckResult()
        {
            var query = new CheckResultQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("newErrors")]
        public async Task<ActionResult> CreateLog([FromBody] Log log)
        {
            var query = new CreateLogCommand()
            {
                Log = log
            };

            try
            {
                await Mediator.Send(query);
                return Ok();
            }
            catch (Exception exception)
            {
                return Problem(title: exception.GetType().Name, statusCode: 500, detail: exception.Message);
            }
        }

        [HttpGet]
        [Route("service/serviceInfo")]
        public async Task<ActionResult<ServiceInfoDTO>> GetServiceInfo()
        {
            var query = new ServiceInfoQuery()
            {
                AssemblyName = Assembly.GetExecutingAssembly().GetName()
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
