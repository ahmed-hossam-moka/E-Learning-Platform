
﻿namespace OnlineLearningPlatform.DAL.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int PaymentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }
        public Payment Payment { get; set; }
        public Earnings Earnings { get; set; }
    }
}
