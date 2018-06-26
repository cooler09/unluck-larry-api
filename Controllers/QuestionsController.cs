using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using unlucky_larry.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unlucky_larry.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private QuestionContext _context;
        public QuestionsController(QuestionContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _context.Questions
                .Include(_ => _.Answers)
                .Select(_ => new Question
                {
                    Id = _.Id,
                    GroupName = _.GroupName,
                    Title = _.Title,
                    Answers = _.Answers.Select(a => new Answer
                    {
                        Id = a.Id,
                        QuestionId = a.QuestionId,
                        Title = a.Title
                    }).ToList()
                })
                .ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Question Get(int id)
        {
            return _context.Questions
                .FirstOrDefault(_ => _.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]QuestionAddModel question)
        {
            var q = question.ToDomain();
            _context.Questions.Add(q);
            _context.SaveChanges();
            q.CorrectAnswer = q.Answers[question.CorrectAnswer].Id;
            _context.Questions.Update(q);
            _context.SaveChanges();

        }

        // PUT api/<controller>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]Question question)
//        {
//            _context.Questions.Update(question);
//            _context.SaveChanges();
//        }
//
//        // DELETE api/<controller>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            var question = _context.Questions.First(_ => _.Id == id);
//            var answersIds = question.Answers.Select(_ => _.Id);
//            foreach (var a in answersIds)
//            {
//                var answer = _context.Answers.Find(a);
//                _context.Answers.Remove(answer);
//            }
//
//            _context.SaveChanges();        
//            _context.Questions.Remove(question);
//            _context.SaveChanges();
//        }
    }
}
