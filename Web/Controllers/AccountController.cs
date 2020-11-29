using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using SpeedrunAppBack.Models;
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
    public class AccountController : ControllerBase
    {
        private readonly SpeedrunDbContext context;
        private readonly IMapper mapper;
        private readonly ILogger<PulseController> logger;

        public AccountController(
            SpeedrunDbContext context,
            IMapper mapper,
            ILogger<PulseController> logger
            )
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("isrunner")]
        [SwaggerOperation(OperationId = "IsRunner")]
        public async Task<ActionResult<bool>> IsRunner()
        {
            if (!HttpContext.Request.Headers.TryGetValue("userid", out var userId))
            {
                return BadRequest("Need userig from vk mini app");
            }
            return (await context.Users.Where(u => u.Id == userId.ToString()).SingleOrDefaultAsync())?.IsRunner ?? false;
        }


        [HttpPost("isrunner/{isRunner}")]
        [SwaggerOperation(OperationId = "SetIsRunner")]
        public async Task<ActionResult<bool>> SetIsRunner(bool isRunner)
        {
            if (!HttpContext.Request.Headers.TryGetValue("userid", out var userId))
            {
                return BadRequest("Need userig from vk mini app");
            }
            logger.LogWarning($"user {userId} to {isRunner}");
            var record = await context.Users.Where(u => u.Id == userId.ToString()).SingleOrDefaultAsync();
            if (record == null)
            {
                record = new UserModel
                {
                    Id = userId
                };
                context.Users.Add(record);
            }
            record.IsRunner = isRunner;
            await context.SaveChangesAsync();
            return record.IsRunner;
        }
    }
}
