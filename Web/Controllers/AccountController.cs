using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
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
        public async Task<bool> IsRunner(
            [Required][FromHeader(Name = "userid")] string userId)
        {
            return (await context.Users.Where(u => u.Id == userId).SingleOrDefaultAsync())?.IsRunner ?? false;
        }


        [HttpPost("isrunner")]
        [SwaggerOperation(OperationId = "SetIsRunner")]
        public async Task<bool> SetIsRunner(
            [Required][FromHeader(Name = "userid")] string userId,
            [Required][FromBody] bool isRunner)
        {
            var record = await context.Users.Where(u => u.Id == userId).SingleOrDefaultAsync();
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
