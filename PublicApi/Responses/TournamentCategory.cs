using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{
    public class TournamentCategory
    {
        public string category { get; set; }
        public List<Tournament> tournaments { get; set; }
    }

    public class Tournament : Stream
    {
        public int StartTime => Math.Abs((previewImage?.GetHashCode() ?? 15) % 24);
    }
}
