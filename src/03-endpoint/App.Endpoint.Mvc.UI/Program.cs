using App.Domain.Core.Contracts;
using App.Domain.Core.Entities;
using App.Infrastructure.Data.Repositories;
using App.Infrastructure.Data.Repositories.AutoMapper;
using App.Infrastructure.DB.SqlServer.EF.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace App.Endpoint.Mvc.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string  not found.");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring));
            var config = new MapperConfiguration(cfg =>
            {
               
                cfg.AddProfile(new AutoMapperProfileDto());
            });

            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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
            // Create or migrate the database
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}