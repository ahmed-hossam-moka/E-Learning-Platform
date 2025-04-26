using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class PaymentReadDto
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime TransactionDate { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
