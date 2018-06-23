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
        public void Post([FromBody]Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var question = _context.Questions.Find(id);
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }
    }
}
