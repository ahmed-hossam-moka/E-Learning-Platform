using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository) {
            _paymentRepository = paymentRepository;
        }
        public IEnumerable<PaymentReadDto> GetAll()
        {
            var paymentModels = _paymentRepository.GetAll();

            var paymentDtos = paymentModels.Select(a => new PaymentReadDto{
                PaymentId = a.PaymentId,
                StudentId = a.StudentId,
                Amount = a.Amount,
                PaymentMethod = a.PaymentMethod,
                TransactionDate = a.TransactionDate,
                Status = a.Status
            }).ToList();
            return paymentDtos;
        }

        public PaymentReadDto GetById(int id)
        {
            var paymentModels = _paymentRepository.GetById(id);

            var paymentDto =  new PaymentReadDto
            {
                PaymentId = paymentModels.PaymentId,
                StudentId = paymentModels.StudentId,
                Amount = paymentModels.Amount,
                PaymentMethod = paymentModels.PaymentMethod,
                TransactionDate = paymentModels.TransactionDate,
                Status = paymentModels.Status
            };
            return paymentDto;
        }

        public void Insert(PaymentAddDto payment)
        {
            var parmentModel = new Payment
            {
                StudentId = payment.StudentId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                TransactionDate = DateTime.UtcNow, 
                Status = PaymentStatus.Completed

            };
            _paymentRepository.Insert(parmentModel);
           
        }
        
    }
}
