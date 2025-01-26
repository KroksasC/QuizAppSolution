using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly QuizQuestionsService _quizQuestionsService;

        public UsersController(QuizQuestionsService quizQuestionsService, UserContext context)
        {
            _context = context;
            _quizQuestionsService = quizQuestionsService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUserItems()
        {

            return await _context.Users.OrderByDescending(s => s.FinalScore)
                .Take(10)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            // Calculate final score
            user.FinalScore = _quizQuestionsService.CalculateFinalScore(user.Answers);

            // Save user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
