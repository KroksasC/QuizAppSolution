using ReactApp1.Server.Models;

namespace ReactApp1.Server.Services
{
    public static class SeedingDataService
    {
        public static void SeedData(QuizQuestionsContext context)
        {
            context.Database.EnsureCreated();

            if (!context.QuizQuestions.Any())
            {
                var quizQuestions = new List<QuizQuestion>
                {
                    // Single-answer questions
                    new QuizQuestion
                    {
                        QuestionText = "What is the capital of France?",
                        QuestionType = "Radio",
                        Options = new List<string> { "Paris", "London", "Berlin", "Rome" },
                        CorrectAnswers = new List<string> { "Paris" }
                    },
                    new QuizQuestion
                    {
                        QuestionText = "What is 2 + 2?",
                        QuestionType = "Radio",
                        Options = new List<string> { "3", "4", "5", "6" },
                        CorrectAnswers = new List<string> { "4" }
                    },
                    new QuizQuestion
                    {
                        QuestionText = "Which is the largest planet?",
                        QuestionType = "Radio",
                        Options = new List<string> { "Earth", "Mars", "Jupiter", "Saturn" },
                        CorrectAnswers = new List<string> { "Jupiter" }
                    },
                    new QuizQuestion
                    {
                        QuestionText = "Which element has the symbol 'O'?",
                        QuestionType = "Radio",
                        Options = new List<string> { "Oxygen", "Osmium", "Oganesson", "Ozone" },
                        CorrectAnswers = new List<string> { "Oxygen" }
                    },

                    // Text input questions
                    new QuizQuestion
                    {
                        QuestionText = "What is the square root of 81?",
                        QuestionType = "Textbox",
                        CorrectAnswers = new List<string> { "9" }
                    },
                    new QuizQuestion
                    {
                        QuestionText = "Name the primary color that is a mix of red and blue.",
                        QuestionType = "Textbox",
                        CorrectAnswers = new List<string> { "Purple" }
                    },

                    // Multiple-answer questions
                    new QuizQuestion
                    {
                        QuestionText = "Select all programming languages:",
                        QuestionType = "Checkbox",
                        Options = new List<string> { "C#", "Python", "HTML", "CSS" },
                        CorrectAnswers = new List<string> { "C#", "Python" }
                    },
                    new QuizQuestion
                    {
                        QuestionText = "Select all fruits:",
                        QuestionType = "Checkbox",
                        Options = new List<string> { "Apple", "Carrot", "Banana", "Tomato" },
                        CorrectAnswers = new List<string> { "Apple", "Banana" }
                    },
                    new QuizQuestion
                    {
                        QuestionText = "Select all prime numbers:",
                        QuestionType = "Checkbox",
                        Options = new List<string> { "2", "3", "4", "6" },
                        CorrectAnswers = new List<string> { "2", "3" }
                    },
                    new QuizQuestion
                    {
                        QuestionText = "Select all countries in Europe:",
                        QuestionType = "Checkbox",
                        Options = new List<string> { "France", "Brazil", "Germany", "India" },
                        CorrectAnswers = new List<string> { "France", "Germany" }
                    }
                };

                context.QuizQuestions.AddRange(quizQuestions);
                context.SaveChanges();
            }
        }
    }
}
