using ReactApp1.Server.Models;

namespace ReactApp1.Server.Services
{
    public class QuizQuestionsService
    {
        private readonly QuizQuestionsContext _context;
        public QuizQuestionsService(QuizQuestionsContext context)
        {
            _context = context;
        }

        public int CalculateFinalScore(List<string> answers)
        {
            var questions = _context.QuizQuestions.ToList();
            int totalScore = 0;

            foreach (var question in questions)
            {
                if (question.QuestionType == "Radio")
                {
                    if (answers.Contains(question.CorrectAnswers.FirstOrDefault()))
                    {
                        totalScore += 100;
                    }
                }
                else if (question.QuestionType == "Checkbox")
                {
                    var userAnswersList = answers
                    .SelectMany(a => a.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    .ToList();
                    var correctAnswers = question.CorrectAnswers;
                    var userCorrectAnswers = correctAnswers.Where(a => userAnswersList.Contains(a)).ToList();

                    int scoreForCheckbox = (int)Math.Round((100.0 / correctAnswers.Count) * userCorrectAnswers.Count);
                    totalScore += scoreForCheckbox;
                }
                else if (question.QuestionType == "Textbox")
                {
                    var userAnswer = answers.FirstOrDefault(a => string.Equals(a, question.CorrectAnswers.FirstOrDefault(), StringComparison.OrdinalIgnoreCase));
                    if (!string.IsNullOrEmpty(userAnswer))
                    {
                        totalScore += 100;
                    }
                }
            }return totalScore;
        }
    }
}
