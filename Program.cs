using GZMaps.Models;
using Microsoft.AspNetCore.HttpOverrides;
using System;

namespace GZMaps
{
    public class Program
    {
        public static EnvironmentEnum _environment = EnvironmentEnum.Development;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            var app = builder.Build();

            app.UseForwardedHeaders();

            if (!app.Environment.IsDevelopment())
            {
                _environment = EnvironmentEnum.Production;
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            if (args.Length > 0)
            {
                if (args[0] == "forceDev")
                {
                    _environment = EnvironmentEnum.Development;
                }
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapFallbackToPage("/Index");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}