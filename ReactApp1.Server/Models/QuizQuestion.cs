using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Models
{
    public class QuizQuestion
    {
        [Key]
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public string? QuestionType { get; set; } // "Radio", "Checkbox", "Textbox"
        public List<string>? Options { get; set; }
        public List<string>? CorrectAnswers { get; set; }
        public string? UserAnswer { get; set; } // For Textbox
        public List<string>? UserAnswers { get; set; } // For Checkbox
    }
}
