using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublicApi.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly ISpeedrunRefit speedrunRefit;
        private readonly IGamesApi gamesInterfase;
        private readonly ILogger<GamesController> _logger;

        public GamesController(
            ISpeedrunRefit speedrunRefit,
            IGamesApi gamesInterfase,
            ILogger<GamesController> logger)
        {
            this.speedrunRefit = speedrunRefit;
            this.gamesInterfase = gamesInterfase;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GetAllGames")]
        public async Task<IEnumerable<Game>> Get(int offset = 0)
        {
            return (await gamesInterfase.Games(offset)).data;
        }

        [HttpGet("byids")]
        [SwaggerOperation(OperationId = "GetGamesById")]
        public async Task<IEnumerable<Game>> GetGamesByIds([FromQuery]List<string> ids)
        {
            var requests = ids.Select(id => speedrunRefit.Game(id)).ToArray();
            var runTasks = ids.Select(id => speedrunRefit.Runs(id)).ToArray();
            await Task.WhenAll(requests);
            var data = requests.Select(r => r.Result.data).ToList();
            await Task.WhenAll(runTasks);
            var runs = runTasks.SelectMany(r => r.Result.data).ToList();
            for (int i = 0; i < data.Count; i++)
            {
                data[i].favoriteTime = runs[i]?.times?.prettyTime;
            }
            return data;
        }

        [HttpGet("compact")]
        [SwaggerOperation(OperationId = "GetCompactGames")]
        public async Task<IEnumerable<GameCompact>> GetCompacts(
            int offset = 0, 
            string platform = "", 
            string sort = "mostactive",
            bool unofficial = false)
        {
            return (await gamesInterfase.GetGameCompacts(offset, platform, sort, unofficial));
        }

        [HttpGet("{gameId}/categories")]
        [SwaggerOperation(OperationId = "GetCategories")]
        public async Task<IEnumerable<Category>> GetCategories(string gameId)
        {
            return await gamesInterfase.Categories(gameId);
        }

        [HttpGet("moderators/{gameId}/{categoryId}")]
        [SwaggerOperation(OperationId = "GetModeratorsIds")]
        public async Task<IEnumerable<string>> GetModeratorsIds(
            [FromServices] SpeedrunDbContext dbContext,
            string gameId, string categoryId)
        {
            return await dbContext.GameCategoryModerators
                .Where(gcm => gcm.GameId == gameId && gcm.CategoryId == categoryId)
                .Select(gcm => gcm.UserId)
                .ToListAsync();
        }
    }
}
