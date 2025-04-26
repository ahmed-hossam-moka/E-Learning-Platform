using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos.Earnings
{
    public class EarningsAddDto
    {
        public int InstructorId { get; set; }
        public int EnrollmentId { get; set; }
        public double Amount { get; set; }
        public EarningsStatus Status { get; set; }
    }
}