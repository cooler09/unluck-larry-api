using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using unlucky_larry.Models;

namespace unlucky_larry.Controllers
{
    [Route("api/[controller]")]
    public class QuestionDataController : Controller
    {
        private readonly QuestionContext _context;
        public QuestionDataController(QuestionContext context)
        {
            _context = context;
        }
        // GET
        [HttpGet]
        public List<QuestionModel> GetQuestionsForGroup(string group)
        {

            return _context.Questions
                .Include(_ => _.Answers)
                .Where(_ => _.GroupName.Equals(group))
                .Select(_ => new QuestionModel
                {
                    Id = _.Id,
                    Title = _.Title,
                    Answers = _.Answers
                        .Select(a => new  AnswerModel
                        {
                            Title = a.Title,
                            Id = a.Id
                        }).ToList()
                })
                .ToList();
        }

        [HttpPost]
        public int Answers(UserAnswerModel model)
        {
            var user = _context.Users.Find(model.UserId);
            foreach (var a in model.Answers)
            {
                var answer = _context.Answers.Find(a);
                _context.UserAnswers.Add(new UserAnswer
                {
                    User = user,
                    Answer = answer
                });
            }

            _context.SaveChanges();

            var score = _context.UserAnswers
                .Include(_ => _.Answer)
                .Include(_ => _.Answer.Question)
                .Include(_ => _.User)
                .Count(_ => _.User.Id == user.Id
                            && _.Answer.Id == _.Answer.Question.CorrectAnswer);   

            return score;
        }
    }
}