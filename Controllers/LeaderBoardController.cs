using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using unlucky_larry.Models;

namespace unlucky_larry.Controllers
{
    [Route("api/[controller]")]
    public class LeaderBoardController : Controller
    {
        
        private readonly QuestionContext _context;
        public LeaderBoardController(QuestionContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<LeaderBoardModel> GetLeaderBoard()
        {

            return _context.LeaderBoards
                .Include(_ => _.User)
                .Select(_ => new LeaderBoardModel{
                    Score = _.Score,
                    Username = _.User.Username
                    })
                .ToList();
        }

        [HttpPost]
        public void AddScore(AddLeaderModel model)
        {
            var user = _context.Users.Find(model.UserId);
            user.Username = model.UserName;
            _context.Users.Update(user);
            _context.LeaderBoards.Add(new LeaderBoard
            {
                Score = model.Score,
                User = user
            });
            _context.SaveChanges();
        }
    }
}