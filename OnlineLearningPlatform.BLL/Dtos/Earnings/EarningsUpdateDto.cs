using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos.Earnings
{
    public class EarningsUpdateDto
    {
        public int EarningId { get; set; }
        public EarningsStatus Status { get; set; }
    }
}