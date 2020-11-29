using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunAppBack.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public bool IsRunner { get; set; }
        public List<UserSubscription> SubscribtionsFrom { get; set; }
        public List<UserSubscription> SubscribtionsTo { get; set; }
    }
}
