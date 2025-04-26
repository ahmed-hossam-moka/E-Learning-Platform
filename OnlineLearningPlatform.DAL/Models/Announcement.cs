namespace OnlineLearningPlatform.DAL.Models
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
