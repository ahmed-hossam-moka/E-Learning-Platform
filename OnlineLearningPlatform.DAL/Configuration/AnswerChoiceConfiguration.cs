using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class AnswerChoiceConfiguration : IEntityTypeConfiguration<AnswerChoice>
    {
        public void Configure(EntityTypeBuilder<AnswerChoice> builder)
        {

            builder.HasKey(a => a.AnswerChoiceId);

            builder.Property(a => a.Text)
                  .IsRequired()
                  .HasMaxLength(300);

            builder.Property(a => a.IsCorrect)
                  .IsRequired();

            builder.HasOne(a => a.Question)
                  .WithMany(a => a.Choices)
                  .HasForeignKey(a => a.QuestionId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
