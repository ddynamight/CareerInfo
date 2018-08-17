using CareerInfo.Model;
using CareerInfo.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CareerInfo.Web
{
     public class Startup
     {
          public IConfigurationRoot Configuration { get; }

          public Startup(IHostingEnvironment env)
          {
               var builder = new ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

               if (env.IsDevelopment())
               {
                    builder.AddUserSecrets<Startup>();
               }

               builder.AddEnvironmentVariables();
               Configuration = builder.Build();
          }

          // This method gets called by the runtime. Use this method to add services to the container.
          // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
          public void ConfigureServices(IServiceCollection services)
          {

               services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

               services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

               services.Configure<IdentityOptions>(options =>
               {
                    // Password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    // Cookie settings
                    options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                    options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
                    options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOff";

                    // User settings
                    options.User.RequireUniqueEmail = true;
               });

               services.AddMvc(options =>
               {
                    //options.SslPort = 8086;
                    //options.Filters.Add(new RequireHttpsAttribute());
               });

               services.AddTransient<IEmailSender, AuthMessageSender>();
               services.AddTransient<ISmsSender, AuthMessageSender>();

          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
          {
               loggerFactory.AddConsole(Configuration.GetSection("Logging"));
               loggerFactory.AddDebug();

               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    //app.UseDatabaseErrorPage();
                    app.UseBrowserLink();
               }
               else
               {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseDeveloperExceptionPage();
               }

               app.UseStaticFiles();

               app.UseIdentity();
               app.UseGoogleAuthentication(new GoogleOptions()
               {
                    ClientId = "273565938163-pprp284joesikvql48trjfr2hidof99r.apps.googleusercontent.com",
                    ClientSecret = "MyRNnuMcNl8qlOTNrZMfS1_K"
               });
               app.UseFacebookAuthentication(new FacebookOptions()
               {
                    AppId = "1433933980054502",
                    AppSecret = "8cff19726d6e8ea9145b45d8c29e01e8"
               });


               app.UseMvc(routes =>
               {
                    routes.MapRoute(
                         name: "areaRoute",
                         template: "{area:exists}/{controller=Home}/{action=Index}/{tag?}"
                         );

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{tag?}");

                    routes.MapRoute(
                         name: "findCourse",
                         template: "{controller=Courses}/{action=Find}/{tagOne?}/{tagTwo?}/{tagThree?}");
               });
          }
     }
}
