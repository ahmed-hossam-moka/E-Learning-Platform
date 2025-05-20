using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos.Withdrawal
{
    public class WithdrawalUpdateDto
    {
        public int WithdrawalId { get; set; }
        public WithdrawalStatus Status { get; set; }
    }
}