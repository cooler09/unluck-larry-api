using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var questions = new Dictionary<string,TriviaInfo>();
            var emo = GetQuestions(GroupName.Emo);
            var hipster = GetQuestions("hipsters");
            var jock = GetQuestions("jocks");
            var nerd = GetQuestions("nerds");
            var popularGirl = GetQuestions("popular-girls");

            questions.Add(GroupName.Emo,new TriviaInfo{
                Questions = emo
            });
            questions.Add(GroupName.Hipster,new TriviaInfo{
                Questions = hipster
            });
            questions.Add(GroupName.Jock,new TriviaInfo{
                Questions = jock
            });
            questions.Add(GroupName.Nerd,new TriviaInfo{
                Questions = nerd
            });
            questions.Add(GroupName.PopularGirl,new TriviaInfo{
               Questions = popularGirl
           });
            var model = new GameStateData
            {
                UserId = 0,
                questions = questions
            };
            return model;
        }
        private List<QuestionVM> GetQuestions(string grp)
        {
            return _context.Questions
                .Include(_ => _.CorrectAnswer)
                .Where(_ => _.GroupName == grp)
                .OrderBy(r => Guid.NewGuid())
                .Take(10)
                .Select(_ => new QuestionVM
                {
                    id = _.Id,
                    correctAnswerId = _.CorrectAnswer,
                    groupName = GroupName.PopularGirl,
                    title = _.Title,
                    answers = _.Answers.Select(a => new AnswerVM
                    {
                        id = a.Id,
                        title = a.Title
                    }).ToList()
                }).ToList();
        }
    
    }
}