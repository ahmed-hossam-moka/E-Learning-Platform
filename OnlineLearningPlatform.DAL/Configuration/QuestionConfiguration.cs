using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.HasKey(a => a.QuestionId);

            builder.Property(a => a.Text)
                  .IsRequired()
                  .HasMaxLength(500);

            builder.HasOne(a => a.Quiz)
                  .WithMany(a => a.Questions)
                  .HasForeignKey(a => a.QuizId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Choices)
                  .WithOne(a => a.Question)
                  .HasForeignKey(a => a.QuestionId);
        }
    }
}
