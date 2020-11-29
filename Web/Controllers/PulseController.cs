using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using PublicApi.Requests;
using PublicApi.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PulseController : ControllerBase
    {
        private readonly SpeedrunDbContext context;
        private readonly IMapper mapper;
        private readonly ILogger<PulseController> logger;

        public PulseController(
            SpeedrunDbContext context,
            IMapper mapper,
            ILogger<PulseController> logger
            )
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet("{gameId}")]
        [SwaggerOperation(OperationId = "GetAllPulseMessages")]
        public async Task<List<PulseMessageResponse>> GetAllPulseMessages(string gameId)
        {
            return await context.PulseMessages
                .Where(m => m.GameId == gameId)
                .OrderByDescending(m => m.SendTime)
                .ProjectTo<PulseMessageResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{gameId}/{from}")]
        [SwaggerOperation( OperationId = "GetPulseMessagesFrom")]
        public async Task<List<PulseMessageResponse>> GetPulseMessagesFrom(string gameId, FromPulseMessage from)
        {
            var isRunner = from == FromPulseMessage.Runners;
            return await context.PulseMessages
                .Where(m => m.GameId == gameId)
                .Where(m => m.User.IsRunner == isRunner)
                .OrderByDescending(m => m.SendTime)
                .ProjectTo<PulseMessageResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [SwaggerOperation(OperationId = "SendPulseMessage")]
        [HttpPost("{gameId}")]
        public async Task<ActionResult<PulseMessageResponse>> Post(
            [Required][FromRoute] string gameId,
            [Required][FromBody] string message)
        {
            if (!HttpContext.Request.Headers.TryGetValue("userid", out var userId))
            {
                return BadRequest("Need userig from vk mini app");
            }
            var record = new PulseMessage
            {
                GameId = gameId,
                Message = message,
                SendTime = DateTimeOffset.Now,
                UserId = userId
            };
            context.PulseMessages.Add(record);
            await context.SaveChangesAsync();
            return mapper.Map<PulseMessageResponse>(record);
        }
    }
}
