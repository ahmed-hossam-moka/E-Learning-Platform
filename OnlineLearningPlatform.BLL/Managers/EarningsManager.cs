// BLL/Managers/EarningsManager.cs
using OnlineLearningPlatform.BLL.Dtos.Earnings;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;
using System.Collections.Generic;
using System.Linq;

namespace OnlineLearningPlatform.BLL.Managers
{
    public class EarningsManager : IEarningsManager
    {
        private readonly IEarningsRepository _earningsRepository;

        public EarningsManager(IEarningsRepository earningsRepository)
        {
            _earningsRepository = earningsRepository;
        }

        public IEnumerable<EarningsReadDto> GetAll()
        {
            var earnings = _earningsRepository.GetAll();
            return earnings.Select(e => new EarningsReadDto
            {
                EarningId = e.EarningId,
                InstructorId = e.InstructorId,
                EnrollmentId = e.EnrollmentId,
                Amount = e.Amount,
                Status = e.Status,
                EarnedAt = e.EarnedAt
            }).ToList();
        }

        public EarningsReadDto GetById(int id)
        {
            var earning = _earningsRepository.GetById(id);
            return new EarningsReadDto
            {
                EarningId = earning.EarningId,
                InstructorId = earning.InstructorId,
                EnrollmentId = earning.EnrollmentId,
                Amount = earning.Amount,
                Status = earning.Status,
                EarnedAt = earning.EarnedAt
            };
        }

        public void Add(EarningsAddDto earning)
        {
            var earningModel = new Earnings
            {
                InstructorId = earning.InstructorId,
                EnrollmentId = earning.EnrollmentId,
                Amount = earning.Amount,
                Status = EarningsStatus.Pending
            };
            _earningsRepository.Add(earningModel);
        }

        public void Update(EarningsUpdateDto earning)
        {
            var earningModel = _earningsRepository.GetById(earning.EarningId);
            earningModel.Status = earning.Status;
            _earningsRepository.UpdateStatus(earning.EarningId, earningModel.Status);
        }
    }
}