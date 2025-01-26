using ReactApp1.Server.Controllers;
using Xunit;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services;
using Microsoft.EntityFrameworkCore;
namespace QuizApp.Tests
{
    public class ControllersTests
    {
        private readonly QuizQuestionsContext _quizContext;
        private readonly UserContext _userContext;
        private readonly QuizQuestionsService _quizService;

        public ControllersTests()
        {
            var quizOptions = new DbContextOptionsBuilder<QuizQuestionsContext>()
                .UseInMemoryDatabase(databaseName: "QuizTestDatabase")
                .Options;
            _quizContext = new QuizQuestionsContext(quizOptions);

            var userOptions = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "UserTestDatabase")
                .Options;
            _userContext = new UserContext(userOptions);

            _quizService = new QuizQuestionsService(_quizContext);
            SeedingDataService.SeedData(_quizContext);
        }

        [Fact]
        public void GetUsers_Returns_The_Correct_Number_Of_Users()
        {
            //Assert
            var randomUsers = GenerateRandomUsers(100);

            
            foreach (var user in randomUsers) 
            {
                _userContext.Add(user);
            }
            _userContext.SaveChanges();
            //Act
            var userController = new UsersController(_quizService, _userContext);
            
            var result = userController.GetUserItems();
            //Asert
            Assert.Equal(10, result.Result.Count());
        }
        /// <summary>
        /// Helper method to generate random users
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<User> GenerateRandomUsers(int count)
        {
            var random = new Random();
            var users = new List<User>();

            for (int i = 0; i < count; i++)
            {
                users.Add(new User
                {
                    Id = i + 1,
                    Email = $"user{random.Next(1, 1000)}@example.com", 
                    FinalScore = random.Next(0, 101), 
                    Answers = new List<string> { "Answer1", "Answer2", "Answer3" }
                });
            }

            return users;
        }

        [Fact]
        public void PostUser_Adds_Users_Correctly()
        {
            //Arrange
            var newUser = new User
            {
                Email = "newuser@example.com",
                Answers = new List<string> { "Answer1", "Answer2" }
            };
            var userController = new UsersController(_quizService, _userContext);
            //Act
            _userContext.Add(newUser);

            _userContext.SaveChanges();

            var result = userController.PostUser(newUser);
            //Assert
            Assert.Equal(101, _userContext.Users.Count());
        }
        [Fact]
        public void GetsQuizes_Returns_Seeded_Quizes ()
        {
            //Arrange

            //Act
            var quizController = new QuizQuestionsController(_quizContext);

            var result = quizController.Get();
            //Assert
            Assert.Equal(_quizContext.QuizQuestions, result.Result);
        }
        [Fact]
        public void CalculateFinalScore_Returns_Correct_Score_For_Textbox_Questions()
        {
            // Arrange
            var answers = new List<string> { "9", "Purple" };

            // Act
            var score = _quizService.CalculateFinalScore(answers);

            // Assert
            Assert.Equal(200, score);
        }
        [Fact]
        public void CalculateFinalScore_Returns_Correct_Score_For_Checkbox_Questions()
        {
            // Arrange
            var answers = new List<string> { "C#", "Python", "Apple", "Banana", "2", "3", "France", "Germany" };

            // Act
            var score = _quizService.CalculateFinalScore(answers);

            // Assert
            Assert.Equal(400, score); 
        }
        [Fact]
        public void CalculateFinalScore_Returns_Zero_When_No_Correct_Answers()
        {
            // Arrange
            var answers = new List<string> { "London", "0", "Earth", "Ozone" };

            // Act
            var score = _quizService.CalculateFinalScore(answers);

            // Assert
            Assert.Equal(0, score);
        }
        [Fact]
        public void CalculateFinalScore_Returns_Partial_Score_For_Checkbox_Questions()
        {
            // Arrange
            var answers = new List<string> { "C#", "Python", "HTML", "Banana", "2", "3", "France" };

            // Act
            var score = _quizService.CalculateFinalScore(answers);

            // Assert
            Assert.Equal(300, score); 
        }
        [Fact]
        public void CalculateFinalScore_Returns_Correct_Score_For_Radio_Questions()
        {
            // Arrange
            var answers = new List<string> { "Paris", "4", "Jupiter", "Oxygen" };

            // Act
            var score = _quizService.CalculateFinalScore(answers);

            // Assert
            Assert.Equal(400, score);
        }
    }
}