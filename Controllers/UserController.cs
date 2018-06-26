using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using unlucky_larry.Models;

namespace unlucky_larry.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly QuestionContext _context;
        public UserController(QuestionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public int Register()
        {
            var user = new User();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }
    }
}