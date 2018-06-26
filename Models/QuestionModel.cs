using System.Collections.Generic;

namespace unlucky_larry.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}