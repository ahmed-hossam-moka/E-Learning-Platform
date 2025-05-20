namespace OnlineLearningPlatform.BLL.Dtos
{
    public class UserLectureProcessToReturnDto
    {
        public int ProgressId { get; set; }
        public string StudentId { get; set; }
        public int LectureId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
