using PublicApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface IStreamsApi
    {
        Task<List<Stream>> GetStreams(string country = "", string haspb = "on", int start = 0);
    }
}
