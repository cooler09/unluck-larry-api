using System.Collections.Generic;
using System.Linq;

namespace unlucky_larry.Models
{
    public class QuestionAddModel
    {
        public string Title { get; set; }
        public int CorrectAnswer { get; set; }
        public string Group { get; set; }
        public List<AnswerAddModel> Answers { get; set; }

        public Question ToDomain()
        {
            var answers = Answers.Select(_ => new Answer
            {
                Title = _.Title
            });
            return new Question
            {
                Title = Title,
                GroupName = Group,
                Answers = answers.ToList()
            };
        }
    }
}