using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizQuestionsController : ControllerBase
    {
        private readonly QuizQuestionsContext _context;

        public QuizQuestionsController(QuizQuestionsContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetQuizQuestions")]
        public async Task<IEnumerable<QuizQuestion>> Get()
        {
            return await _context.QuizQuestions.ToListAsync();
        }
    }
}
