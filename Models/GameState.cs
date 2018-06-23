using System.Collections.Generic;

namespace unlucky_larry.Models
{
    public class GameState
    {
        public int Id { get; set; }
        public string Player { get; set; }
        public int Points { get; set; }
        public SceneType CurrentScene { get; set; }
        public string CurrentEnemyName { get; set; }
        public List<int> CurrentQuestionIds { get; set; }
    }
}