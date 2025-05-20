
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineLearningPlatform.DAL.DataBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using OnlineLearningPlatform.BLL.Managers.Users;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.BLL.Managers;
using OnlineLearningPlatform.DAL.Repository;
using OnlineLearningPlatform.BLL.Managers.Auth;
using OnlineLearningPlatform.DAL.Repository.Users;
using OnlineLearningPlatform.DAL.Repository.Quizs;
using OnlineLearningPlatform.BLL.Managers.Quizs;
using OnlineLearningPlatform.Api.Controllers.CustomExceptionMiddleware;



namespace OnlineLearningPlatform.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PlatformContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<PlatformContext>()
                            .AddDefaultTokenProviders();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";
                options.DefaultChallengeScheme = "Jwt";
            })
            .AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])
                    )
                };
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("StudentPolicy", policy => policy.RequireRole("Student"));
                options.AddPolicy("InstructorPolicy", policy => policy.RequireRole("Instructor"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            //GlobalException handler service
            builder.Services.AddExceptionHandler<GlobalException>();
            builder.Services.AddProblemDetails();


            // Ahmed Registers
            builder.Services.AddScoped<IAuthManager, AuthManager>();
            builder.Services.AddScoped<IStudentManager, StudentManager>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IInstructorManager, InstructorManager>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();



            // Nour Registers
            builder.Services.AddScoped<ILectureManager, LectureMnanager>();
            builder.Services.AddScoped<ILectureRepository, LectureRepository>();
            builder.Services.AddScoped<ILectureAttachmentManager, LectureAttachmentManager>();
            builder.Services.AddScoped<ILectureAttachmentRepository, LectureAttachmentRepository>();


            // Marwan Registers
            builder.Services.AddScoped<ICourseManager, CourseManager>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();



            // Haidy registers
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IEarningsRepository, EarningsRepository>();
            builder.Services.AddScoped<IWithdrawalRepository, WithdrawalRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IReviewManager, ReviewManager>();
            builder.Services.AddScoped<IEarningsManager, EarningsManager>();
            builder.Services.AddScoped<IWithdrawalManager, WithdrawalManager>();
            builder.Services.AddScoped<IAdminManager, AdminManager>();



            // Safaa registers
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IPaymentManager, PaymentManager>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<IEnrollmentManager, EnrollmentManager>();


            builder.Services.AddScoped<IQuizRepository, QuizRepository>();
            builder.Services.AddScoped<IQuizService, QuizService>();
            //builder.Services.AddScoped<IQuizResultRepository, QuizResultRepository>();
            //builder.Services.AddScoped<IQuizResultService, QuizResultService>();
            builder.Services.AddScoped<IUserLectureProgressRepository, UserLectureProgressRepository>();
            builder.Services.AddScoped<IUserLectureProgressService, UserLectureProgressService>();






            //builder.Services.AddScoped<IQuizSubmissionService, QuizSubmissionService>();
            //builder.Services.AddScoped<IQuizResultRepository, QuizResultRepository>();

            builder.Services.AddScoped<IStudentAnswerRepository, StudentAnswerRepository>();
            builder.Services.AddScoped<IUserLectureProgressRepository, UserLectureProgressRepository>();
            
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IUserLectureProgressRepository, UserLectureProgressRepository>();
            




            var app = builder.Build();


            app.UseExceptionHandler(opt => { });


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthentication(); 
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
