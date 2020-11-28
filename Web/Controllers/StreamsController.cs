using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublicApi.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreamsController : ControllerBase
    {
        private readonly IStreamsApi streamsApi;
        private readonly ILogger<StreamsController> _logger;

        public StreamsController(
            IStreamsApi streamsApi,
            ILogger<StreamsController> logger)
        {
            this.streamsApi = streamsApi;
            _logger = logger;
        }
        [SwaggerOperation(OperationId = "GetStreams")]
        [HttpGet]
        public async Task<List<Stream>> GetStreams(string country = "", string haspb = "on", int start = 0)
        {
            return await streamsApi.GetStreams(country, haspb, start);
        }
    }
}
