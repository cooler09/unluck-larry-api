using System.Collections.Generic;

namespace unlucky_larry.Models
{
    public class GameStateData
    {
        public int UserId { get; set; }
        public Dictionary<string,TriviaInfo> questions { get; set; }
    }
}