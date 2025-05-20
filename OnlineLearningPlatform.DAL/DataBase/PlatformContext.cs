using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.DAL.Configuration;
using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.DataBase
{
    public class PlatformContext : IdentityDbContext<ApplicationUser> 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlatformContext(DbContextOptions<PlatformContext> db, IHttpContextAccessor httpContextAccessor)
            : base(db)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new AdminConfiguration());
            //modelBuilder.ApplyConfiguration(new StudentConfiguration());
            //modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new CourseConfiguration());
            //modelBuilder.ApplyConfiguration(new LectureConfiguration());
            //modelBuilder.ApplyConfiguration(new LectureAttachmentConfiguration());
            //modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
            //modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            //modelBuilder.ApplyConfiguration(new CartConfiguration());
            //modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            //modelBuilder.ApplyConfiguration(new QuizConfiguration());
            //modelBuilder.ApplyConfiguration(new QuizResultConfiguration());
            //modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            //modelBuilder.ApplyConfiguration(new EarningsConfiguration());
            //modelBuilder.ApplyConfiguration(new WithdrawalConfiguration());
            //modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            //modelBuilder.ApplyConfiguration(new UserLectureProgressConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(PlatformContext)
                        .GetMethod(nameof(SetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        private static void SetSoftDeleteFilter<T>(ModelBuilder builder) where T : class, ISoftDeletable
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        public override int SaveChanges()
        {
            // Handle BaseEntity tracking
            var baseEntityEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && !(e.Entity is ISoftDeletable) && e.State != EntityState.Unchanged);

            var currentUserId = GetCurrentUserId();

            foreach (var entry in baseEntityEntries)
            {
                var entity = (BaseEntity)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedAt = DateTime.UtcNow;
                        entity.CreatedBy = currentUserId;
                        entity.DeletedBy = currentUserId;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedAt = DateTime.UtcNow;
                        entity.UpdatedBy = currentUserId;
                        break;
                }
            }

            // Handle ISoftDeletable entities
            var softDeleteEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is ISoftDeletable && e.State == EntityState.Deleted);

            foreach (var entry in softDeleteEntries)
            {
                var entity = (ISoftDeletable)entry.Entity;
                entry.State = EntityState.Modified;
                entity.IsDeleted = true;

                if (entity is BaseEntity baseEntity)
                {
                    baseEntity.DeletedAt = DateTime.UtcNow;
                    baseEntity.DeletedBy = currentUserId;
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Handle BaseEntity tracking
            var baseEntityEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && !(e.Entity is ISoftDeletable) && e.State != EntityState.Unchanged);

            var currentUserId = GetCurrentUserId();

            foreach (var entry in baseEntityEntries)
            {
                var entity = (BaseEntity)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedAt = DateTime.UtcNow;
                        entity.CreatedBy = currentUserId;
                        entity.DeletedBy = currentUserId;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedAt = DateTime.UtcNow;
                        entity.UpdatedBy = currentUserId;
                        break;
                }
            }

            // Handle ISoftDeletable entities
            var softDeleteEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is ISoftDeletable && e.State == EntityState.Deleted);

            foreach (var entry in softDeleteEntries)
            {
                var entity = (ISoftDeletable)entry.Entity;
                entry.State = EntityState.Modified;
                entity.IsDeleted = true;

                if (entity is BaseEntity baseEntity)
                {
                    baseEntity.DeletedAt = DateTime.UtcNow;
                    baseEntity.DeletedBy = currentUserId;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        private string GetCurrentUserId()
        {
            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId ?? "System";
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureAttachment> LectureAttachments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Earnings> Earnings { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserLectureProgress> UserLectureProgresses { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerChoice> AnswerChoices { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }


    }
}
