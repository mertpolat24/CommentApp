using CommentApp_Services.Contracts;
using CommentApp_Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CommentApp_Repositories.Contracts;
using CommentApp_Repositories;
using CommentApp_Repositories.Contexts;

namespace CommentApp_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddAutoMapper(typeof(Program));


            var connection = string.Empty;

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn")));


            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (context.Database.CanConnect())
                    Console.WriteLine("\n\n-db connection SUCCESSFUL-\n\n");
                else
                    Console.WriteLine("\n\n-db connection FAILED-\n\n");
            }
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
