using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{
    public class PulseMessageResponse
    {
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset SendTime { get; set; }
    }
}
