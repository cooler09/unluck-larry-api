using System.Collections.Generic;

namespace unlucky_larry.Models
{
    public class QuestionData
    {
        public string Title { get; set; }
        public List<AnswerData> Answers { get; set; }
    }
}