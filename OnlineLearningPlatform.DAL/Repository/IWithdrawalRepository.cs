using OnlineLearningPlatform.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IWithdrawalRepository
    {
        IQueryable<Withdrawal> GetAll();
        Withdrawal GetById(int id);
        IEnumerable<Withdrawal> GetWithdrawalsByInstructor(string instructorId);
        void Add(Withdrawal withdrawal);
        void UpdateStatus(int withdrawalId, WithdrawalStatus status);
        void Delete(int id);
    }
}