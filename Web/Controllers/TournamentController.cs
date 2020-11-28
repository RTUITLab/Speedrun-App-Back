using AutoMapper;
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
    public class TournamentController : ControllerBase
    {
        private readonly IStreamsApi streamsApi;
        private readonly IMapper mapper;
        private readonly ILogger<TournamentController> logger;

        private string[] categories = new string[] {
            "Any% Glitchless",
            "Any%",
            "All Achievements",
            "All Advancements",
            "Any% Glitchless (Peaceful)"
        };

        public TournamentController(
            IStreamsApi streamsApi, 
            IMapper mapper,
            ILogger<TournamentController> logger)
        {
            this.streamsApi = streamsApi;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GetTournament")]
        public async Task<IEnumerable<TournamentCategory>> GetTournament()
        {
            Stream getStream(List<Stream> streams, Random rand)
            {
                var stream = streams[rand.Next(streams.Count)];
                streams.Remove(stream);
                return stream;
            }
            var streams = await streamsApi.GetStreams();
            var random = new Random();
            return categories
                .Select(c => (category: c, count: random.Next(1, 5)))
                .Select(p => new TournamentCategory
                {
                    category = p.category,
                    tournaments = Enumerable.Repeat(0, p.count)
                                        .Select(_ => getStream(streams, random))
                                        .Select(s => mapper.Map<Tournament>(s))
                                        .ToList()
                }).ToList();
        }
    }
}
