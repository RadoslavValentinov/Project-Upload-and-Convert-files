using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Infrastructure.Data.Models;
using UploadFiles.Infrastruction;

namespace UploadFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool result = IronOcr.License.IsValidLicense("IRONSUITE.RACHKOO21.GMAIL.COM.4044-8A82F40030-FQXWLOFES2GZR4-FN2G64UON6MJ-5JVL2UEMQFSR-AWA6J4UZXF7N-CUGWOHTZPUNH-KK3VDXQ2FNRN-IWO4P5-TJMS4IVJWVWLUA-DEPLOYMENT.TRIAL-QU3WCU.TRIAL.EXPIRES.24.FEB.2024");


            var builder = WebApplication.CreateBuilder(args);

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlServer(connectionString);
            //});
            //builder.Services.AddDbContext<ApplicationDbContext>();
            //builder.Services.AddApplicationServiceApp();


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
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
