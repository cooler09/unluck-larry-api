using Microsoft.AspNetCore.Mvc;
using unlucky_larry.Models;

namespace unlucky_larry.Controllers
{
    [Route("api/[controller]")]
    public class GameStateController:Controller
    {
        private readonly QuestionContext _context;
        public GameStateController(QuestionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public GameStateData Get()
        {
            var user = new User();
            _context.Users.Add(user);
            _context.SaveChanges();

            var model = new GameStateData
            {
                UserId = user.Id
            };
            return model;
        }
    }
}