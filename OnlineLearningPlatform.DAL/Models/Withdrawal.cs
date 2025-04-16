using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Models
{
    public class Withdrawal
    {
        public int WithdrawalId { get; set; }
        public int InstructorId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public WithdrawalStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
        public Instructor Instructor { get; set; }
        public Earnings Earnings { get; set; }
    }
}
