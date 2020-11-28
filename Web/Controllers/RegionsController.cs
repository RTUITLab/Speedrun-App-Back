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
    public class RegionsController : ControllerBase
    {
        private readonly ISpeedrunRefit speedrunApi;
        private readonly ILogger<RegionsController> _logger;

        public RegionsController(
            ISpeedrunRefit speedrunapi,
            ILogger<RegionsController> logger)
        {
            this.speedrunApi = speedrunapi;
            _logger = logger;
        }
        [SwaggerOperation(OperationId = "GetRegions")]
        [HttpGet]
        public async Task<List<Region>> GetRegions()
        {
            return (await speedrunApi.Regions()).data;
        }
    }
}
