using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public CourseStatus Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Instructor Instructor { get; set; }
        public Category Category { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
