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
    public class LeaderBoardsController : ControllerBase
    {
        private readonly ISpeedrunRefit speedrunRefit;
        private readonly ILogger<LeaderBoardsController> logger;

        public LeaderBoardsController(ISpeedrunRefit speedrunRefit, ILogger<LeaderBoardsController> logger)
        {
            this.speedrunRefit = speedrunRefit;
            this.logger = logger;
        }

        [HttpGet("{gameId}/{categoryId}")]
        [SwaggerOperation(OperationId = "GetLeaderboard")]
        public async Task<Leaderboard> GetLeaderboard(string gameId, string categoryId)
        {
            return (await speedrunRefit.Leaderboard(gameId, categoryId)).data;
        }
    }
}
