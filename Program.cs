using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RSWEBBookShop.Data;
using RSWEBBookShop.Interfaces;
using RSWEBBookShop.Models;
using RSWEBBookShop.Services;
using Microsoft.AspNetCore.Identity;
using RSWEBBookShop.Areas.Identity.Data;
using System;

namespace RSWEBBookShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<RSWEBBookShopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RSWEBBookShopContext") ?? throw new InvalidOperationException("Connection string 'RSWEBBookShopContext' not found.")));

            //builder.Services.AddDefaultIdentity<RSWEBBookShopUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RSWEBBookShopUserContext>();

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddRazorPages();
            builder.Services.AddIdentity<RSWEBBookShopUser, IdentityRole>().AddEntityFrameworkStores<RSWEBBookShopContext>().AddDefaultUI().AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30); 
                options.Lockout.MaxFailedAccessAttempts = 10; 
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true; 
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
                options.LoginPath = $"/Identity/Account/Login"; 
                options.LogoutPath = $"/Identity/Account/Logout"; 
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied"; 
                options.SlidingExpiration = true;
            });

            builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();
            builder.Services.AddTransient<IStreamFileUploadService, StreamFileUploadLocalService>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initalize(services);
            }

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
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Books}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();
        }
    }
}