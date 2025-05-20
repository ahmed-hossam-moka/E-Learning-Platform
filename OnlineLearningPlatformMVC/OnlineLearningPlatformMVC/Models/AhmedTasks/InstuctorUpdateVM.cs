namespace OnlineLearningPlatformMVC.Models.AhmedTasks
{
    public class InstructorUpdateVM
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
