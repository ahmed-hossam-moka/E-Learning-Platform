using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class StudentAnswerConfiguration : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {

            builder.HasKey(a => a.StudentAnswerId);

            builder.Property(a => a.IsCorrect)
                  .IsRequired();

            builder.HasOne(a => a.QuizResult)
                  .WithMany(a => a.Answers)
                  .HasForeignKey(a => a.QuizResultId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Question)
                  .WithMany()
                  .HasForeignKey(a => a.QuestionId)
                  .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(a => a.SelectedAnswer)
                  .WithMany()
                  .HasForeignKey(sa => sa.SelectedAnswerId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
