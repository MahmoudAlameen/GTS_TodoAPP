using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TodoApp.Application;
using TodoApp.Domain;
using TodoApp.MVC.Handlers;
using static System.Formats.Asn1.AsnWriter;

namespace TodoApp.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTodoAppDbContext(builder.Configuration);
            builder.Services.AddRepositories();
            builder.Services.AddApplication();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
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
                pattern: "{controller=Todo}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
              using (var concreteContext = scope.ServiceProvider.GetService<TodoAppDbContext>())
              {
                  concreteContext.Database.Migrate();
              }
            }

                        app.Run();
        }
    }
}
