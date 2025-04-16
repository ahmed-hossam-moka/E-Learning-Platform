using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Models
{
    public class Earnings
    {
        public int EarningId { get; set; }
        public int InstructorId { get; set; }
        public int EnrollmentId { get; set; }
        public double Amount { get; set; }
        public EarningsStatus Status { get; set; }
        public DateTime EarnedAt { get; set; }
        public Instructor Instructor { get; set; }
        public Enrollment Enrollment { get; set; }
        public ICollection<Withdrawal> Withdrawals { get; set; }
    }
}
