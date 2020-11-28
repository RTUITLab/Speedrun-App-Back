using PublicApi.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public interface IGamesApi
    {
        Task<SpeedranResponseWrapper<List<Game>>> Games(int offset=0);
        Task<List<GameCompact>> GetGameCompacts(int start = 0, string platform = null, string sort = "mostactive", bool unofficial = false);
        Task<List<Category>> Categories(string gameId);
    }
}
