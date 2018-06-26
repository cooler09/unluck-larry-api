namespace unlucky_larry.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Answer Answer { get; set; }
    }
}