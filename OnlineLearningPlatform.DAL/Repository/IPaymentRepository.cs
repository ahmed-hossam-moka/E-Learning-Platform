using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public interface IPaymentRepository
    {
        IQueryable<Payment> GetAll();
        Payment GetById(int id);
        void Insert(Payment payment);


    }
}
