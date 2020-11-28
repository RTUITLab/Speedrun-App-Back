using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{
    public class Stream
    {
        public string id { get; set; }
        public string twichUrl { get; set; }
        public string previewImage { get; set; }
        public string streamTitle { get; set; }
        public int watchingCount { get; set; }
        public string flagImage { get; set; }
        public string nickName { get; set; }
        public string streamsLink { get; set; }
        public string gameTitle { get; set; }
        public string gameCoverImage { get; set; }
    }
}
