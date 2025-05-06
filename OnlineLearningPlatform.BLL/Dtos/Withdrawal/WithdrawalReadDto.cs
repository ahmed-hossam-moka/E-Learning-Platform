using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos.Withdrawal
{
    public class WithdrawalReadDto
    {
        public int WithdrawalId { get; set; }
        public string InstructorId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public WithdrawalStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}