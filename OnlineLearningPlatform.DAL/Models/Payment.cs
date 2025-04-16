using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime TransactionDate { get; set; }
        public PaymentStatus Status { get; set; }
        public Student Student { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
