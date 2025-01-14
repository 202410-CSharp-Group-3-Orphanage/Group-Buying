using Microsoft.Data.SqlClient;
using PlatformManagement.Models.Repositories;
using PlatformManagement.Models.Service;

namespace PlatformManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<MemberService>();
            builder.Services.AddScoped<SqlConnection>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            });
            
            builder.Services.AddScoped<MemberRepository>();

            builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Members/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
