
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
            builder.Services.AddDbContext<PlatformContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddScoped<IInstructorManager, InstructorManager>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

            builder.Services.AddScoped<ILectureManager, LectureMnanager>();
            builder.Services.AddScoped<ILectureRepository, LectureRepository>();

            builder.Services.AddScoped<ILectureAttachmentManager, LectureAttachmentManager>();
            builder.Services.AddScoped<ILectureAttachmentRepository, LectureAttachmentRepository>();





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
