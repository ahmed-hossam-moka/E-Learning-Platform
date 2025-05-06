using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Dtos
{
    public class PaymentAddDto
    {
        public string StudentId { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

    }
}
