using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unlucky_larry.Models
{
    public class QuestionContext: DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        
    }
}
