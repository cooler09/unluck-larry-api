using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using unlucky_larry.Models;

namespace unlucky_larry.Controllers
{
    public class GameController : Controller
    {
        private QuestionContext _context;
        public GameController(QuestionContext context)
        {
            _context = context;
        }

        public int Register(string name)
        {
            return 1;
        }
        // GET
        public GameState LoadGame(int id)
        {
            return new GameState
            {
                Id = 1,
                Player = "Larry",
                Points = 1000,
                CurrentEnemyName = "Jocks",
                CurrentQuestionIds = new List<int>{1,2,3,4}
            };
        }
    }
}