using Microsoft.AspNetCore.Mvc;

namespace Phase3Section2._24
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy =
                    SameSiteMode.None;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes => { 
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                
                routes.MapRoute(
                   name: "studentId",
                   template: "Student/{id}",
                  defaults: new { controller = "Home", action = "StudentInfo1" });

                routes.MapRoute(
                   name: "studentIdName",
                   template: "Student/{id}/{name}",
                  defaults: new { controller = "Home", action = "StudentInfo1" });

            });

            app.Run();
        }
    }
}