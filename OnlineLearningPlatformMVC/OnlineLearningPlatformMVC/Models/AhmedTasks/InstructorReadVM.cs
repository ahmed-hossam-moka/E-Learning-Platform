namespace OnlineLearningPlatformMVC.Models.AhmedTasks
{
    public class InstructorReadVM
    {
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
