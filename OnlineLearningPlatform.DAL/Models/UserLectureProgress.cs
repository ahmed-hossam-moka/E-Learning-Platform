namespace OnlineLearningPlatform.DAL.Models
{
    public class UserLectureProgress
    {
        public int ProgressId { get; set; }
        public string StudentId { get; set; }
        public int LectureId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletedAt { get; set; }
        public Student Student { get; set; }
        public Lecture Lecture { get; set; }
    }
}
