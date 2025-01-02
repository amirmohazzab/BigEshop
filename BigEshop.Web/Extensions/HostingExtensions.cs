using BigEshop.Application.Statics;
using BigEshop.Data.Context;
using BigEshop.Ioc.Container;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using System.Data;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace BigEshop.Web.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication RegisterServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region NLog
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

            #endregion

            #region Config DbContext

            string connectionString = builder.Configuration.GetConnectionString("BigEshopConnectionString");

            builder.Services.AddScoped<IDbConnection>((sp) =>
            {
                return new SqlConnection(connectionString);
            });

            builder.Services.AddDbContext<BigEshopContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            #endregion

            #region Config Services

            builder.Services.RegisterService();

            builder.Services.AddHttpClient();

            #endregion

            #region HtmlEncoder

            builder.Services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
            UnicodeRanges.Arabic }));

            #endregion

            #region Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.LogoutPath = "/logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                });

            #endregion

            #region Config Kavenegar api

            builder.Configuration.GetSection("KavenegarSms").Get<KavenegarStatics>();
            #endregion

            #region Config Job

            builder.Services.RegisterJobs();

            #endregion

            //builder.Services.AddSignalR();

            //builder.Services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(policy =>
            //                      {
            //                          policy.AllowAnyOrigin()
            //                                .AllowAnyMethod()
            //                                .AllowAnyHeader();
            //                      });
            //});

            var app = builder.Build();

            return app;
        }

        public static WebApplication RegisterPipeLines(this  WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapHub<ChatHub>("/chatHub");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            return app;
        }
    }
}
