using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PlatformContext _context;

        public PaymentRepository(PlatformContext context)
        {
            _context = context;
        }
        public IQueryable<Payment> GetAll()
        {

            return _context.Payments;

        }

        public Payment GetById(int id)
        {

            return _context.Payments.Find(id);
        }
        public void Insert(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        
    }
}
