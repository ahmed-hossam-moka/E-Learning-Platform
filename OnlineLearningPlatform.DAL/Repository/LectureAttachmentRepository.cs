using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository
{
    public class LectureAttachmentRepository : ILectureAttachmentRepository
    {
        private readonly PlatformContext _context;

        public LectureAttachmentRepository(PlatformContext context)
        {
            _context = context;
        }

        public IQueryable<LectureAttachment> GetAll()
        {
            return _context.LectureAttachments;
        }

        public LectureAttachment GetById(int id)
        {
            return _context.LectureAttachments.FirstOrDefault(a => a.AttachmentId == id);
        }

        public void Insert(LectureAttachment lectureAttachment)
        {
            _context.LectureAttachments.Add(lectureAttachment);
            _context.SaveChanges();
        }

        public void Update(LectureAttachment lectureAttachment)
        {
           // _context.LectureAttachments.Update(lectureAttachment);
            _context.SaveChanges();
        }

        public void Delete(LectureAttachment lectureAttachment)
        {
            _context.LectureAttachments.Remove(lectureAttachment);
            _context.SaveChanges();
        }
    }
}
