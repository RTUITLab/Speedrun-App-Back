using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunsController : ControllerBase
    {
        private readonly ISpeedrunRefit speedrunApi;
        private readonly ILogger<RegionsController> _logger;

        public RunsController(
            ISpeedrunRefit speedrunapi,
            ILogger<RegionsController> logger)
        {
            this.speedrunApi = speedrunapi;
            _logger = logger;
        }
        [HttpGet]
        [SwaggerOperation(OperationId = "GetLatestRuns")]
        public async Task<List<SpeedrunAppBack.PublicApi.Responses.Run.RunModel>> LatestRuns()
        {
            var runs = await speedrunApi.Runs(new string[] { "players", "game", "platform" });
            return runs.data;
        }
    }
}
