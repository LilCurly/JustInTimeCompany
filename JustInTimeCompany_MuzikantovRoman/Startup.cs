using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Commands.CreateUser;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace JustInTimeCompany_MuzikantovRoman
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommand>())
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<JustInTimeCompanyDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<AppUser, IdentityRole>().AddRoles<IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<JustInTimeCompanyDbContext>();

            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IPlaneRepository, PlaneRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, JustInTimeCompanyDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            JustInTimeCompanyInitializer.Initiliaze(context, userManager, roleManager);

            app.UseStaticFiles(new StaticFileOptions{OnPrepareResponse = ctx =>
            {
                const int duration = 60 * 60 * 24;
                ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public, max-age=" + duration;
            }});

            app.UseAuthentication();
            app.UseMvc(routes => routes.MapRoute(name: "Default", template: "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
