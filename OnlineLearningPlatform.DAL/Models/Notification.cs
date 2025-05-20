namespace OnlineLearningPlatform.DAL.Models
{
    public class Notification : ISoftDeletable
    {
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public ApplicationUser User { get; set; }
    }
}
