namespace OnlineLearningPlatform.BLL.Dtos.Withdrawal
{
    public class WithdrawalAddDto
    {
        public string InstructorId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
