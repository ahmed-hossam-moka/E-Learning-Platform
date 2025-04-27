using OnlineLearningPlatform.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IEarningsRepository
    {
        IQueryable<Earnings> GetAll();
        Earnings GetById(int id);
        IEnumerable<Earnings> GetEarningsByInstructor(int instructorId);
        decimal GetTotalEarnings(int instructorId);
        void Add(Earnings earning);
        void UpdateStatus(int earningId, EarningsStatus status);
        void Delete(int id);
    }
}