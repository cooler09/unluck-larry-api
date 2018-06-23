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
        public List<QuestionData> GetQuestionsForGroup(string group)
        {

            return _context.Questions
                .Include(_ => _.Answers)
                .Where(_ => _.GroupName.Equals(group))
                .Select(_ => new QuestionData
                {
                    Title = _.Title,
                    Answers = _.Answers
                        .Select(a => new  AnswerData
                        {
                            Title = a.Title,
                            Id = a.Id
                        }).ToList()
                })
                .ToList();
        }
    }
}