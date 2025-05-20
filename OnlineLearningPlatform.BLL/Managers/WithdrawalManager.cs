using OnlineLearningPlatform.BLL.Dtos.Withdrawal;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;
using System.Collections.Generic;
using System.Linq;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class WithdrawalManager : IWithdrawalManager
    {
        private readonly IWithdrawalRepository _withdrawalRepository;

        public WithdrawalManager(IWithdrawalRepository withdrawalRepository)
        {
            _withdrawalRepository = withdrawalRepository;
        }

        public IEnumerable<WithdrawalReadDto> GetAll()
        {
            var withdrawals = _withdrawalRepository.GetAll();
            return withdrawals.Select(w => new WithdrawalReadDto
            {
                WithdrawalId = w.WithdrawalId,
                InstructorId = w.InstructorId,
                Amount = w.Amount,
                PaymentMethod = w.PaymentMethod,
                Status = w.Status,
                RequestedAt = w.RequestedAt
            }).ToList();
        }

        public WithdrawalReadDto GetById(int id)
        {
            var withdrawal = _withdrawalRepository.GetById(id);
            return new WithdrawalReadDto
            {
                WithdrawalId = withdrawal.WithdrawalId,
                InstructorId = withdrawal.InstructorId,
                Amount = withdrawal.Amount,
                PaymentMethod = withdrawal.PaymentMethod,
                Status = withdrawal.Status,
                RequestedAt = withdrawal.RequestedAt
            };
        }

        public void Add(WithdrawalAddDto withdrawal)
        {
            var withdrawalModel = new Withdrawal
            {
                InstructorId = withdrawal.InstructorId,
                Amount = withdrawal.Amount,
                PaymentMethod = withdrawal.PaymentMethod,
                Status = WithdrawalStatus.Pending
            };
            _withdrawalRepository.Add(withdrawalModel);
        }

        public void Update(WithdrawalUpdateDto withdrawal)
        {
            var withdrawalModel = _withdrawalRepository.GetById(withdrawal.WithdrawalId);
            withdrawalModel.Status = withdrawal.Status;
            _withdrawalRepository.UpdateStatus( withdrawal.WithdrawalId, withdrawalModel.Status);
        }
    }
}