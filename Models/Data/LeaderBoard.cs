namespace unlucky_larry.Models
{
    public class LeaderBoard
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public User User { get; set; }
    }
}