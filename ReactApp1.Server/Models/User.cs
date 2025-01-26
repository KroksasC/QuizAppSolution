using System.ComponentModel.DataAnnotations;

namespace ReactApp1.Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        
        public List<string>? Answers { get; set; }
        public int? FinalScore { get; set; }
    }
}
