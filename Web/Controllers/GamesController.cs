﻿using Microsoft.AspNetCore.Mvc;
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
    public class GamesController : ControllerBase
    {
        private readonly IGamesApi gamesInterfase;
        private readonly ILogger<GamesController> _logger;

        public GamesController(
            IGamesApi gamesInterfase,
            ILogger<GamesController> logger)
        {
            this.gamesInterfase = gamesInterfase;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GetAllGames")]
        public async Task<IEnumerable<Game>> Get(int offset = 0)
        {
            return (await gamesInterfase.Games(offset)).data;
        }

        [HttpGet("compact")]
        [SwaggerOperation(OperationId = "GetCompactGames")]
        public async Task<IEnumerable<GameCompact>> GetCompacts(int offset = 0)
        {
            return (await gamesInterfase.GetGameCompacts(offset));
        }
    }
}