using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunAppBack.Models
{
    public class UserSubscription
    {
        public string User1Id { get; set; }
        public UserModel User1 { get; set; }
        public string User2Id { get; set; }
        public UserModel User2 { get; set; }

    }
}
