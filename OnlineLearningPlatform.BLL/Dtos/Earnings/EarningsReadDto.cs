﻿using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos.Earnings
{
    public class EarningsReadDto
    {
        public int EarningId { get; set; }
        public string InstructorId { get; set; }
        public int EnrollmentId { get; set; }
        public double Amount { get; set; }
        public EarningsStatus Status { get; set; }
        public DateTime EarnedAt { get; set; }
    }
}