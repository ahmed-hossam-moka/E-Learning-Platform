using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class WithdrawalRepository : IWithdrawalRepository
    {
        private readonly PlatformContext _context;

        public WithdrawalRepository(PlatformContext context)
        {
            _context = context;
        }

        public IQueryable<Withdrawal> GetAll()
        {
            return _context.Withdrawals.AsQueryable();
        } 

        public Withdrawal GetById(int id)
        {
            return _context.Withdrawals.FirstOrDefault(w => w.WithdrawalId == id);
        }

        public IEnumerable<Withdrawal> GetWithdrawalsByInstructor(string instructorId)
        {
            return _context.Withdrawals.Where(w => w.InstructorId == instructorId).ToList();
        }

        public void Add(Withdrawal withdrawal)
        {
            _context.Withdrawals.Add(withdrawal);
            _context.SaveChanges();
        }

        public void UpdateStatus(int withdrawalId, WithdrawalStatus status)
        {
            _context.Withdrawals
                .Where(w => w.WithdrawalId == withdrawalId)
                .ExecuteUpdate(w => w
                    .SetProperty(w => w.Status, status));
        }

        public void Delete(int id)
        {
            _context.Withdrawals.Where(w => w.WithdrawalId == id).ExecuteDelete();
        }
    }
}