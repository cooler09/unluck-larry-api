using System.Collections.Generic;
using System.Linq;

namespace unlucky_larry.Models
{
    public class QuestionVM
    {
        
        public int id { get; set; }
        public string title { get; set; }
        public string groupName { get; set; }
        public int correctAnswerId { get; set; }
        public List<AnswerVM> answers { get; set; }

        public void Populate(Question question)
        {
            id = question.Id;
            title = question.Title;
            groupName = question.GroupName;
            correctAnswerId = question.CorrectAnswer;
            answers = question.Answers
                .Select(_ => new AnswerVM
                {
                    id = _.Id,
                    title = _.Title
                })
                .ToList();
        }
    }
}