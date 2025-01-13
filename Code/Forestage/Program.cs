using Forestage.Models.EFModels;
using Forestage.Models.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Forestage.Models.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Forestage.Common;

namespace Forestage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // �Ĥ@�B : �K�[�������ҪA��
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Members/Login";
                    options.LogoutPath = "/Members/Logout"; // �n�X����

                    // todo ��L�t�m
                    options.Cookie.Name = "GroupBuying03.Cookie";
                    options.Cookie.HttpOnly = true; // �L�k�ϥ�JavaScriptŪ��
                });

            builder.Services.AddScoped<MemberService>();
            builder.Services.AddScoped<MemberEFRepository>();
            builder.Services.AddScoped<EmailService>();


            // Entity Framework
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Dapper
            builder.Services.AddTransient<SqlConnection>(provider =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            });

            // Services
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<ShopService>();
            builder.Services.AddScoped<CartService>();
            // Repositories
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<ShopRepository>();
            builder.Services.AddScoped<CartRepository>();

            // Common
            builder.Services.AddSingleton<FilePathHelper>();

			//CORS
			builder.Services.AddCors(
				options =>
				{
					options.AddPolicy("CorsPolicy",
						builder =>
						{
							builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
						});
				});


			builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //CORS
            app.UseCors("CorsPolicy");

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

            // �ĤG�B : �ϥΨ������ҪA��, ���ǫܭ��n, �����bUseAuthorization���e
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
