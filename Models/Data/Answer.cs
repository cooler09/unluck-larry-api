﻿namespace unlucky_larry.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public Question Question{ get; set; }
    }
}