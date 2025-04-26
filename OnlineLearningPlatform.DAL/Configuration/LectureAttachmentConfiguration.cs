using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class LectureAttachmentConfiguration : IEntityTypeConfiguration<LectureAttachment>
    {
        public void Configure(EntityTypeBuilder<LectureAttachment> builder)
        {
            builder.HasKey(a => a.AttachmentId);

            builder.Property(a => a.FileUrl)
                .IsRequired();

            // Relationship with Lecture
            builder.HasOne(a => a.Lecture)
                .WithMany(a => a.Attachments)
                .HasForeignKey(a => a.LectureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
