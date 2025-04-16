namespace OnlineLearningPlatform.DAL.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public User User { get; set; }
    }
}
