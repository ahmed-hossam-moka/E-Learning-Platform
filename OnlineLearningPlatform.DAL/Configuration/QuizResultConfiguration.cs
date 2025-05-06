using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class QuizResultConfiguration : IEntityTypeConfiguration<QuizResult>
    {
        public void Configure(EntityTypeBuilder<QuizResult> builder)
        {
            builder.HasKey(a => a.QuizResultId);

            builder.Property(a => a.Score)
                .IsRequired();

            builder.Property(a => a.TakenAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(a => a.Student)
                .WithMany(a => a.QuizResults)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Quiz)
                .WithMany(a => a.QuizResults)
                .HasForeignKey(a => a.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint for student-quiz combination
            builder.HasIndex(a => new { a.StudentId, a.QuizId })
                .IsUnique();
        }
    }
}
