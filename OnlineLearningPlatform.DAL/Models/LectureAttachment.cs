namespace OnlineLearningPlatform.DAL.Models
{
    public class LectureAttachment : ISoftDeletable
    {
        public int AttachmentId { get; set; }
        public int LectureId { get; set; }
        public string FileUrl { get; set; }
        public bool IsDeleted { get; set; }

        public Lecture Lecture { get; set; }
    }
}
