namespace OnlineLearningPlatform.DAL.Models
{
    public class EnumsBase
    {
        public enum UserRole
        {
            Student,
            Instructor,
            Admin
        }

        public enum CourseStatus
        {
            Draft,
            PendingApproval,
            Published
        }

        public enum PaymentMethod
        {
            PayPal,
            Stripe
        }

        public enum PaymentStatus
        {
            Success,
            Failed,
            Pending
        }

        public enum EarningsStatus
        {
            Pending,
            Withdrawn
        }

        public enum WithdrawalStatus
        {
            Pending,
            Processed
        }
    }
}
