using System.ComponentModel.DataAnnotations;

namespace OnlineLearningPlatformMVC.Models.AhmedTasks
{
    public class RegisterVM
    {
            [Required, StringLength(128)]
            public string Email { get; set; }

            [Required, StringLength(256)]
            public string Password { get; set; }

            [Required, StringLength(256)]
            public string ConfirmPassword { get; set; }

            [Required, StringLength(10)]
            public string Role { get; set; }

    }
}
