
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.BLL.Managers;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Repository;
using System.Reflection.Metadata.Ecma335;

namespace OnlineLearningPlatform.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database Context
            builder.Services.AddDbContext<PlatformContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });


            // Repositories (DAL)
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IEarningsRepository, EarningsRepository>();
            builder.Services.AddScoped<IWithdrawalRepository, WithdrawalRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();

            // Managers (BLL)
            builder.Services.AddScoped<IInstructorManager, InstructorManager>();
            builder.Services.AddScoped<IReviewManager, ReviewManager>();
            builder.Services.AddScoped<IEarningsManager, EarningsManager>();
            builder.Services.AddScoped<IWithdrawalManager, WithdrawalManager>();
            builder.Services.AddScoped<IAdminManager, AdminManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
