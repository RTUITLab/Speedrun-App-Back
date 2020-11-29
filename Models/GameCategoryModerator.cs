using SpeedrunAppBack.Models;
using System;

namespace Models
{
    public class GameCategoryModerator
    {
        public string GameId { get; set; }
        public string CategoryId { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
    }
}
