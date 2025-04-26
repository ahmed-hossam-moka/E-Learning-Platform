using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class EarningsRepository : IEarningsRepository
    {
        private readonly PlatformContext _context;

        public EarningsRepository(PlatformContext context)
        {
            _context = context;
        }

        public IQueryable<Earnings> GetAll()
        {
           return _context.Earnings.AsQueryable();
        }

        public Earnings GetById(int id)
        {
           return _context.Earnings.FirstOrDefault(e => e.EarningId == id);
        }

        public IEnumerable<Earnings> GetEarningsByInstructor(int instructorId)
        {
            return _context.Earnings.Where(e => e.InstructorId == instructorId).ToList();
        }

        public decimal GetTotalEarnings(int instructorId)
        {
             return _context.Earnings
                .Where(e => e.InstructorId == instructorId && e.Status == EarningsStatus.Completed)
                .Sum(e => (decimal)e.Amount);
        }

        public void Add(Earnings earning)
        {
            _context.Earnings.Add(earning);
            _context.SaveChanges();
        }

        public void UpdateStatus(int earningId, EarningsStatus status)
        {
            _context.Earnings
                .Where(e => e.EarningId == earningId)
                .ExecuteUpdate(e => e
                    .SetProperty(e => e.Status, status));
        }

        public void Delete(int id)
        {
            _context.Earnings.Where(e => e.EarningId == id).ExecuteDelete();
        }
    }
}