using PublicApi.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public interface ISpeedrunRefit
    {
        [Get("/api/v1/games")]
        Task<SpeedranResponseWrapper<List<Game>>> Games(int offset=0);
        [Get("/api/v1/games/{gameId}/categories")]
        Task<SpeedranResponseWrapper<List<Category>>> Categories(string gameId);
        [Get("/ajax_streams.php")]
        Task<HttpResponseMessage> Streams(string country, string haspb, int start);

        [Get("/api/v1/regions")]
        Task<SpeedranResponseWrapper<List<Region>>> Regions();
        [Get("/api/v1/platforms")]
        Task<SpeedranResponseWrapper<List<Platform>>> Platforms(int offset);
    }
}
