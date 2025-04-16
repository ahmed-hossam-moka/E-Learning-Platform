namespace OnlineLearningPlatform.DAL.Models
{
    public class Instructor
    {

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public ICollection<Earnings> Earnings { get; set; }
        public ICollection<Withdrawal> Withdrawals { get; set; }
    }
}
