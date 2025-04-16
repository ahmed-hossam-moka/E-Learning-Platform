
namespace OnlineLearningPlatform.DAL.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<QuizResult> QuizResults { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<UserLectureProgress> LectureProgresses { get; set; }
    }
}
