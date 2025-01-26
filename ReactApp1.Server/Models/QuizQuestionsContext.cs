using Microsoft.EntityFrameworkCore;

namespace ReactApp1.Server.Models
{
    public class QuizQuestionsContext : DbContext
    {
        public QuizQuestionsContext(DbContextOptions<QuizQuestionsContext> options) : base(options)
        {

        }

        public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
    }
}
