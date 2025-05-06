namespace OnlineLearningPlatform.DAL.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int OrderInCourse { get; set; }
        public Course Course { get; set; }
        public ICollection<LectureAttachment> Attachments { get; set; }
        public ICollection<UserLectureProgress> UserProgresses { get; set; }
    }
}
