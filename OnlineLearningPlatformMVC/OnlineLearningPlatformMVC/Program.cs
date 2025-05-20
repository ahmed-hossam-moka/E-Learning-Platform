using OnlineLearningPlatform.MVC.Services;

namespace OnlineLearningPlatformMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient();


            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Instructor", policy => policy.RequireRole("Instructor"));
            //    options.AddPolicy("Student", policy => policy.RequireRole("Student"));
            //});


            // Configure HttpClient
            builder.Services.AddHttpClient<IQuizApiService, QuizApiService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7234/"); 
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });



            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
