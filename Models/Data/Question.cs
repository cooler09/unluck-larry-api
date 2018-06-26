using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unlucky_larry.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GroupName { get; set; }
        public int CorrectAnswer { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
