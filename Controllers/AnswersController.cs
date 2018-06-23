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
    public class AnswersController : Controller
    {
        private QuestionContext _context;
        public AnswersController(QuestionContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Answer> Get()
        {
            return _context.Answers
                .ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Answer Get(int id)
        {
            return _context.Answers
                .FirstOrDefault(_ => _.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Answer answer)
        {
            _context.Answers.Update(answer);
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var answer = _context.Answers.Find(id);
            _context.Answers.Remove(answer);
            _context.SaveChanges();
        }
    }
}
