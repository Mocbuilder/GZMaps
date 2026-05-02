using GZMaps.Models;
using System;

namespace GZMaps
{
    public class Program
    {
        public static EnvironmentEnum _environment = EnvironmentEnum.Development;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services FIRST
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure middleware after Build()

            if (!app.Environment.IsDevelopment())
            {
                _environment = EnvironmentEnum.Production;
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Razor Pages
            app.MapRazorPages();

            // Controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapFallbackToController("Index", "t");

            app.Run();
        }
    }
}