using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Models;
namespace OnlineLearningPlatform.DAL.Configuration
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(a => a.QuizId);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.PassingScore)
                .IsRequired();

            //builder.Property(a => a.CreatedAt)
            //    .IsRequired()
            //    .HasDefaultValueSql("GETDATE()");

            // Relationship with Course
            builder.HasOne(a => a.Course)
                .WithMany(a => a.Quizzes)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Questions)
                  .WithOne(qst => qst.Quiz)
                  .HasForeignKey(qst => qst.QuizId);

            builder.HasMany(q => q.QuizResults)
                  .WithOne(r => r.Quiz)
                  .HasForeignKey(r => r.QuizId);
        }
    }
}
