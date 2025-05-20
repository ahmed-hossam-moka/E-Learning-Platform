using System.ComponentModel.DataAnnotations;

namespace OnlineLearningPlatformMVC.Models.AhmedTasks
{
    public class LoginVM
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
