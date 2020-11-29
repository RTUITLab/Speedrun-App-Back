using SpeedrunAppBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PulseMessage
    {
        public string GameId { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public string Message { get; set; }
        public DateTimeOffset SendTime { get; set; }
    }
}
