namespace OnlineLearningPlatform.BLL.Dtos.Withdrawal
{
    public class WithdrawalAddDto
    {
        public int InstructorId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
