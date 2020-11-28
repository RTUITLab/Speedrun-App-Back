using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ISpeedrunRefit speedrunRefit;
        private readonly ILogger<PlatformsController> _logger;

        public PlatformsController(
            ISpeedrunRefit speedrunRefit,
            ILogger<PlatformsController> logger)
        {
            this.speedrunRefit = speedrunRefit;
            _logger = logger;
        }
        [SwaggerOperation(OperationId = "GetPlatforms")]
        [ResponseCache(Duration = 60 * 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        [HttpGet]
        public async Task<List<Platform>> GetPlatforms()
        {
            List<Platform> platforms = new List<Platform>();
            int offset = 0;
            var result = await speedrunRefit.Platforms(offset);
            while (result.pagination.size != 0)
            {
                platforms.AddRange(result.data);
                offset += result.pagination.size;
                result = await speedrunRefit.Platforms(offset);
            }
            return platforms;
        }


    }
}
