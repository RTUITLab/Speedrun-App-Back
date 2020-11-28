using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{
    public class GameCompact
    {
        public string id { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public int activePlayers { get; set; }
    }
}
